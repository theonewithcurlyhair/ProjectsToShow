using BIgSystemSolutions_Web.Models;
using BLL;
using Microsoft.Ajax.Utilities;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private OrderBL orderBL = new OrderBL();

        [HttpGet]
        [Authenticate]
        [Route("PurchaseOrder/BrowsePOs")]
        public ActionResult Index()
        {
            TempData["OrderVM"] = null;
            ViewData["ProcessSort"] = false;
            return View(orderBL.RetrieveOrdersForBrowsing((User)Session["User"]));
        }

        #region Request PO

        [HttpGet]
        [Authenticate]
        public ActionResult RequestNew()
        {
            OrderVM vm = new OrderVM();
            vm.Order = new PurchaseOrder();
            vm.Order.CreatedEmployee = (User)Session["User"];
            TempData["OrderVM"] = vm;
            return View("MaintainPO", TempData["OrderVM"]);
        }

        [HttpGet]
        [Authenticate]
        public ActionResult MaintainPO(int PurchaseOrderID)
        {
            OrderVM vm = new OrderVM();
            vm.Order = orderBL.RetrieveOrder(PurchaseOrderID);
            TempData["OrderVM"] = vm;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authenticate]
        public ActionResult MaintainPO(OrderVM orderVm)
        {
            orderVm.Order = TempData["OrderVM"] != null && ((OrderVM)TempData["OrderVM"]).Order != null ? ((OrderVM)TempData["OrderVM"]).Order : new PurchaseOrder();
            //restrict modifying before validation
            if (orderVm.Item != null) orderBL.RestrictModifying(orderVm.Order, (User)Session["User"], orderVm.Item);
            if (ModelState.IsValid)
            {
                //Temporary fix
                if (orderVm.Item.Errors.Count > 0)
                {
                    TempData["OrderVM"] = orderVm;
                    return View(orderVm);
                }

                PurchaseOrder workingPO = orderVm.Order;
                if (workingPO.Items.Count == 0)
                {
                    workingPO.AddItem(orderVm.Item);
                    workingPO.CreatedEmployee = (User)Session["User"];
                    if (!orderBL.InitPORequest(orderVm.Order))
                    {
                        orderVm.Item = null;
                        orderVm.Order.Items = new List<Item>();
                    }
                }
                else
                {
                    if (workingPO.Items.Exists(i => i.ID == orderVm.Item.ID))
                    {
                        //Modify
                        workingPO.Items[workingPO.Items.IndexOf(workingPO.Items.Where(i => i.ID == orderVm.Item.ID).First())] = orderVm.Item;
                    }
                    else
                    {
                        //Add new
                        workingPO.AddItem(orderVm.Item);
                    }
                    if (!orderBL.ModifyOrder(workingPO))
                    {
                        orderVm.Order = orderBL.RetrieveOrder(workingPO.ID);
                        orderVm.Order.Errors = workingPO.Errors;
                        return View(orderVm);
                    }
                }
                orderVm.Item = null;
            }

            TempData["OrderVM"] = orderVm;
            return View(orderVm);
        }

        [Authenticate]
        public ActionResult CreateNewItem()
        {
            OrderVM vm = TempData["OrderVM"] != null ? ((OrderVM)TempData["OrderVM"]) : new OrderVM();
            vm.Item = new Item();
            vm.Order = vm.Order == null ? new PurchaseOrder() : vm.Order;
            vm.Order.Errors = new List<Error>();
            vm.Order.CreatedEmployee = vm.Order.CreatedEmployee.FName == null ? (User)Session["User"] : vm.Order.CreatedEmployee;
            TempData["OrderVM"] = vm;
            return View("MaintainPO", vm);
        }

        [Authenticate]
        public ActionResult ModifyItem(int itemId)
        {
            OrderVM vm = (OrderVM)TempData["OrderVM"];
            vm.Item = orderBL.RetrieveItem(itemId);
            vm.Order.Errors = new List<Error>();
            TempData["OrderVM"] = vm;
            return View("MaintainPO", vm);
        }

        [Authenticate] 
        public ActionResult RemoveItem(int itemId)
        {
            OrderVM vm = (OrderVM)TempData["OrderVM"];
            orderBL.RemoveItem(vm.Order.Items.Find(i => i.ID == itemId), vm.Order, (User)Session["User"]);
            vm.Item.Errors = new List<Error>();
            vm.Item.Error = null;
            vm.Item = null;

            TempData["OrderVM"] = vm;
            return View("MaintainPO", vm);
        }

        [Authenticate]
        public ActionResult RequestOrder()
        {
            PurchaseOrder orderToRequest = ((OrderVM)TempData["OrderVM"]).Order;
            orderBL.InitPORequest(orderToRequest);

            return RedirectToAction("Index");
        }

        [Authenticate]
        public ActionResult CloseOrder()
        {
            OrderVM vm = (OrderVM)TempData["OrderVM"];
            PurchaseOrder orderToClose = vm.Order;
            if (orderBL.CloseOrder(orderToClose))
            {
                ViewBag.Message = $"Order with ID #{orderToClose.ID} was successfully closed and email was sent";
            }
            else
            {
                ViewBag.Message = "Something went wrong";
            }
            TempData["OrderVM"] = vm;
            return View("MaintainPO", vm);
        }

        [Authenticate]
        [HttpGet]
        [Route("PurchaseOrder/ProcessPOs")]
        public ActionResult ProcessPOs()
        {
            ViewData["ProcessSort"] = true;
            return View("Index", orderBL.RetrieveOrdersForProcessing((User)Session["User"])); 
        }

        #endregion
    }
}