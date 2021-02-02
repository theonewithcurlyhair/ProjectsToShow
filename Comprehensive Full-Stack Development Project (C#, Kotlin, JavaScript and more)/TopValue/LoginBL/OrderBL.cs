using Model;
using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderBL
    {
        private OrderDB orderRepo = new OrderDB();
        private SendEmailBL emailBL = new SendEmailBL();

        #region Business Rules and Validation
        /// <summary>
        ///  Check for Item Duplication Business Rule, deletes duplicated item from items list
        /// </summary>
        /// <param name="po"></param>
        /// <returns>Duplicated item or null</returns>
        public Item DuplicatedItem(PurchaseOrder po)
        {
            foreach (Item firstItem in po.Items)
            {
                foreach (Item secondItem in po.Items.Where(i => i != firstItem).ToList())
                {
                    if (firstItem.Name == secondItem.Name && firstItem.Description == secondItem.Description && firstItem.Location == secondItem.Location && firstItem.Justification == secondItem.Justification && firstItem.Price == secondItem.Price)
                    {
                        firstItem.Quantity += secondItem.Quantity;
                        po.Items.Remove(secondItem);
                        return secondItem;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Restriction BR : If Item is not processed can be modified. We'll check it on representative layer.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Boolean value if item is processed</returns>
        public bool CheckItemProcessed(Item item)
        {
            if (item.Status == ItemStatus.Approved || item.Status == ItemStatus.Denied)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Restriction BR : Checks if order is closed
        /// </summary>
        /// <param name="po"></param>
        /// <returns>Order Closed or not</returns>
        public bool CheckIfOrderClosed(PurchaseOrder po)
        {
            if (po.Status == OrderStatus.Closed)
            {
                po.AddError(new Error(105, "PO Modification Rules ", "Can't add items to a closed order request"));
                return true;
            }
            return false;
        }


        /// <summary>
        /// Restriction BR : Checks if Order can be closed by current user
        /// </summary>
        /// <param name="po"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool CanBeClosed(PurchaseOrder po, User u)
        {
            if (po.Items.Count == 0 || po == null || po.Status == OrderStatus.Closed) return false;
            foreach(Item i in po.Items.Where(i=> !i.NoLongerNeeded))
            {
                if (i.Errors.Count > 0) return false;
            }
            if (po.Items.Where(i => i.Status == ItemStatus.Pending).ToList().Count == 0 && u.IsSupervisor && po.CreatedEmployee.ID != u.ID) return true;
            else return false;
        }

        /// <summary>
        /// Restriction BR : Checks if item can be processed by current user
        /// </summary>
        /// <param name="po"></param>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool CanBeProcessed(PurchaseOrder po, User u, Item i)
        {
            if (po != null && i != null && po.ID != 0 && po.CreatedEmployee.ID != u.ID && u.IsSupervisor && i.ID != 0) return true;
            else return false;
        }

        /// <summary>
        /// Restriction BR : Checks if user can modify PO
        /// </summary>
        /// <param name="po"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CanModify(PurchaseOrder po, User user)
        {
            if (po.CreatedEmployee.ID != user.ID && !user.IsSupervisor)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Restriction BR : If not the same employee who initiated PO - Can modify only certain fields. Restricted Modify Mode
        /// </summary>
        /// <param name="po"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool RestrictedModifyMode(PurchaseOrder po, User user)
        {
            if (po.ID > 0 && po.CreatedEmployee.ID != user.ID) return true;
            return false;
        }

        /// <summary>
        /// Restriction BR : Checks if user cann add items to that PO
        /// </summary>
        /// <param name="po"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CanAddItems(PurchaseOrder po, User user)
        {
            if (po.Items.Count == 0 || (po.CreatedEmployee.ID == user.ID && !CheckIfOrderClosed(po))) return true;
            return false;
        }

        #endregion

        #region Implementation
        /// <summary>
        /// Sets RestrictedModifying to positive if Item was changed. Modify reason will be required 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="user"></param>
        /// <param name="itemToModify"></param>
        /// <returns></returns>
        public bool RestrictModifying(PurchaseOrder order, User user, Item itemToModify)
        {
            if (order.CreatedEmployee.ID != user.ID)
            {
                Item iBefore = order.Items.Find(i => i.ID == itemToModify.ID);
                if (iBefore == null)
                {
                    return false;
                }
                if (iBefore.Location != itemToModify.Location || iBefore.Quantity != itemToModify.Quantity || itemToModify.Price != iBefore.Price)
                {
                    //iBefore.RestrictedModifying = true;
                    itemToModify.RestrictedModifying = true;
                }
                return true;
            }
            return false;

        }

        /// <summary>
        /// Initiates PO with first item and initiating employee
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public bool InitPORequest(PurchaseOrder po)
        {
            return orderRepo.InitPO(po);
        }


        /// <summary>
        /// Modifies item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ModifyItem(Item item)
        {
            return orderRepo.ModifyItem(item);
        }

        /// <summary>
        /// Add items to orders
        /// </summary>
        /// <param name="po"></param>
        /// <param name="itemToAdd"></param>
        /// <returns></returns>
        private bool AddItemToOrder(PurchaseOrder po, Item itemToAdd)
        {
            CheckIfOrderClosed(po);
            if (po.Errors.Count == 0) return orderRepo.InsertItem(itemToAdd, po.ID);
            else return false;
        }

        /// <summary>
        /// Removes Item from PO and DB if duplicated
        /// </summary>
        /// <param name="current"></param>
        /// <param name="po"></param>
        /// <param name="u"></param>
        public void RemoveItem(Item current, PurchaseOrder po, User u)
        {
            current.NoLongerNeeded = true;
            current.Quantity = 0;
            current.Price = 0;
            current.Description = "No longer needed";
            current.Status = ItemStatus.Denied;
            current.Location = "No longer needed";
            current.Justification = "No longer needed";
            ModifyOrder(po);
        }

        /// <summary>
        /// Modifies PO in the DB
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public bool ModifyOrder(PurchaseOrder po)
        {
            if (po.Errors.Count == 0)
            {
                Item duplicated = DuplicatedItem(po);
                if(duplicated != null)
                {
                    orderRepo.DeleteDuplicatedItem(duplicated.ID);
                }
                foreach (Item item in po.Items)
                {
                    if (item.ID == 0)
                    {
                        if(!AddItemToOrder(po, item))
                        {
                            return false;
                        }
                    }
                    else if (!ModifyItem(item))
                    {
                        return false;
                    }
                }
                return orderRepo.ModifyOrder(po);
            }
            return false;
        }

        /// <summary>
        /// Closes PO and Sends notification email to the initiating employees email
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public bool CloseOrder(PurchaseOrder po)
        {
            try
            {
                po.Status = OrderStatus.Closed;
                ModifyOrder(po);


                Email email = new Email();
                email.EmailFrom = "bigsystemsolutions@gmail.com";
                email.EmailTo = po.CreatedEmployee.Email; //change to actual email of created employee
                email.EmailSubject = $"Closing Notification | Purchase Order #{po.ID}";

                email.EmailBody = $"<h3>Purchase order #{po.ID} was successfully closed today {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToShortTimeString()} \n Details are below</h3>";

                email.EmailBody += "<style>" +
                    "table {border - collapse: collapse;}table, th, td {border: 1px solid black;}</style>";
                email.EmailBody += "<table>";
                email.EmailBody += "<thead><tr><td><strong>Item Name</strong></td><td><strong>Qty</strong></td>"
                    + $"<td>"
                    + $"<strong>Description</strong>"
                    + "</td>"
                    + $"<td>"
                    + $"<strong> Justification </strong>"
                    + $"</td>"
                    + $"<td>"
                    + $"<strong> Location </strong>"
                    + $"</td>"
                    + $"<td>"
                    + $"<strong> Price </strong>"
                    + $"</td>"
                    + $"<td>"
                    + $"<strong> Subtotal </strong>"
                    + $"</td>"
                    + $"<td>"
                    + $"<strong> Status </strong>"
                    + $"</td>"
                    + $"<td> "
                    + $"<strong> Modify Reason </strong>"
                    + $"</td>"
                    + $"<td>"
                    + $"<strong> Deny Reason </strong>"
                    + $"</td>"
                    + $"</tr>"
                    + $"</thead><tbody>";

                foreach (Item i in po.Items)
                {
                    email.EmailBody += $"<tr>";
                    email.EmailBody += $"<td>{i.Name}</td>";
                    email.EmailBody += $"<td>{i.Quantity}</td>";
                    email.EmailBody += $"<td>{i.Description}</td>";
                    email.EmailBody += $"<td>{i.Justification}</td>";
                    email.EmailBody += $"<td>{i.Location}</td>";
                    email.EmailBody += $"<td>{i.Price.ToString("c")}</td>";
                    email.EmailBody += $"<td>{i.Subtotal.ToString("c")}</td>";
                    email.EmailBody += $"<td>{i.Status}</td>";
                    email.EmailBody += i.ModifyReason != "" && i.ModifyReason != null ? $"<td>{i.ModifyReason}</td>" : $"<td>Not Applicable</td>";
                    email.EmailBody += i.DenyReason != "" && i.DenyReason != null ? $"<td>{i.DenyReason}</td>" : $"<td>Not Applicable</td>";
                    email.EmailBody += $"</tr>";
                }

                email.EmailBody += "<tr>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td></td>"
                    + $"<td>"
                    + $"</td>"
                    + $"<td></td>"
                    + $"</tr>";

                email.EmailBody += "<tr>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td>"
                    +$"<strong>Subtotal</strong>"
                    +$"</td>"
                    +$"<td>{po.Subtotal.ToString("c")}</td>"
                    + $"</tr>";
                
                email.EmailBody += "<tr>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td>"
                    +$"<strong>Sales Tax</strong>"
                    +$"</td>"
                    +$"<td>{po.Taxes.ToString("c")}</td>"
                    + $"</tr>";
                
                email.EmailBody += "<tr>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td></td>"
                    +$"<td>"
                    +$"<strong>Total</strong>"
                    +$"</td>"
                    +$"<td>{po.Total.ToString("c")}</td>"
                    + $"</tr>";

                email.EmailBody += $"To see more details <a href=\"http://localhost:7900/PurchaseOrder/MaintainPO?PurchaseOrderID={po.ID}\">Click Here</a>";

                return emailBL.SendEmail(email, "mazafaka778@gmail.com", "Ylm.Bumk-999%");
            }
            catch (Exception ex)
            {
                po.AddError(new Error(ex.Message));
                return false;
            }
        }

        #endregion

        #region Get Data
        /// <summary>
        /// Retrieves Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item RetrieveItem(int itemId)
        {
            return orderRepo.GetItem(itemId);
        }

        /// <summary>
        /// Retrieves all PO for employee or all POs in the same department where created employee department is
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<PurchaseOrder> RetrieveOrdersForEmployee(User user)
        {
            //Not a supervisor - retireve only his/her order request where under review
            if (!user.IsSupervisor)
            {
                return orderRepo.GetOrders().Where(o => o.CreatedEmployee.ID == user.ID).ToList();
            }
            else
            {
                //Check later that only Emp in the same department
                return orderRepo.GetOrders().Where(o => o.CreatedEmployee.Departments.DepartmentID == user.Departments.DepartmentID).ToList();
            }

        }

        /// <summary>
        /// Retrieves Orders for processing
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<PurchaseOrder> RetrieveOrdersForProcessing(User user)
        {
            return orderRepo.GetOrders().Where(o => o.CreatedEmployee.Departments.DepartmentID == user.Departments.DepartmentID && o.CreatedEmployee.ID != user.ID).ToList();
        }

        /// <summary>
        /// Retrieves Orders for browsing
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<PurchaseOrder> RetrieveOrdersForBrowsing(User user)
        {
            return orderRepo.GetOrders().Where(o => o.CreatedEmployee.ID == user.ID).ToList();
        }

        /// <summary>
        /// Retrieves PO by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PurchaseOrder RetrieveOrder(int id)
        {
            return orderRepo.GetOrder(id);
        }
        #endregion
    }
}
