using DAL;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Types.Types;

namespace SQLLayer
{
    public class OrderDB
    {
        private DataAccess dal = new DataAccess();
        private const string SP_CREATE_ITEM = "sp_CreateItem";
        private const string SP_CREATE_ORDER = "sp_CreateOrder";
        private const string SP_GET_ORDERS = "sp_GetPurchaseOrders";
        private const string SP_GET_ORDER_DETAILS = "sp_GetPurchaseOrderDetails";
        private const string SP_GET_ORDER_ITEMS = "sp_GetPurchaseOrderItems";
        private const string SP_MODIFY_ITEM = "sp_ModifyItem";
        private const string SP_MODIFY_ORDER = "sp_ModifyPurchaseOrder";
        private const string SP_GET_ITEM = "sp_GetItemDetails";
        private const string SP_DELETE_ITEM = "sp_DeleteItem";

        public bool InsertItem(Item item, int? orderId = 0)
        {
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@name", item.Name, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@desc", item.Description, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@qty", item.Quantity, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@price", item.Price, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@subtotal", item.Subtotal, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@justification", item.Justification, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@location", item.Location, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@status", item.Status, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@id", item.ID, System.Data.SqlDbType.Int, ParameterDirection.Output));
                parms.Add(new ParmStruct("@timeStamp", item.TimeStamp, System.Data.SqlDbType.Timestamp, ParameterDirection.Output));
                if (orderId != null && orderId > 0)
                {
                    parms.Add(new ParmStruct("@orderID", (int)orderId, SqlDbType.Int));
                }

                int insertSuccess = dal.ExecuteNonQuery(SP_CREATE_ITEM, System.Data.CommandType.StoredProcedure, parms);
                if(insertSuccess > 0)
                {
                    item.ID = Convert.ToInt32(parms.Where(p => p.Name == "@id").First().Value);
                    item.TimeStamp = (byte[])parms.Where(p => p.Name == "@timeStamp").First().Value;
                }
                return insertSuccess > 0;

            }
            catch (Exception ex)
            {
                item.AddError(new Error(ex.Message));
                return false;
            }
        }
        public bool InitPO(PurchaseOrder order)
        {
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@id", order.ID, System.Data.SqlDbType.Int, System.Data.ParameterDirection.Output));
                parms.Add(new ParmStruct("@timestamp", order.TimeStamp, System.Data.SqlDbType.Timestamp, System.Data.ParameterDirection.Output));
                parms.Add(new ParmStruct("@date", order.OrderDate, System.Data.SqlDbType.Date));
                parms.Add(new ParmStruct("@subtotal", order.Subtotal, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@taxes", order.Taxes, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@total", order.Total, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@empID", order.CreatedEmployee.ID, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@status", (int)order.Status, System.Data.SqlDbType.Int));

                parms.Add(new ParmStruct("@name", order.Items.First().Name, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@desc", order.Items.First().Description, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@qty", order.Items.First().Quantity, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@price", order.Items.First().Price, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@item_subtotal", order.Items.First().Subtotal, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@justification", order.Items.First().Justification, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@location", order.Items.First().Location, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@item_status", order.Items.First().Status, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@item_id", order.Items.First().ID, System.Data.SqlDbType.Int, ParameterDirection.Output));
                parms.Add(new ParmStruct("@item_timestamp", order.Items.First().TimeStamp, System.Data.SqlDbType.Timestamp, ParameterDirection.Output));


                int insertSuccess = dal.ExecuteNonQuery("sp_InitPO", System.Data.CommandType.StoredProcedure, parms);
                if (insertSuccess > 0)
                {
                    order.ID = Convert.ToInt32(parms[0].Value);
                    order.TimeStamp = (byte[])parms[1].Value;
                    order.Items.First().ID = Convert.ToInt32(parms.Where(p => p.Name == "@item_id").First().Value);
                    order.Items.First().TimeStamp = (byte[])parms.Where(p => p.Name == "@item_timestamp").First().Value;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                order.AddError(new Error(ex.Message));
                return false;
            }
        }

        public bool DeleteDuplicatedItem(int iD)
        {
            return dal.ExecuteNonQuery(SP_DELETE_ITEM, CommandType.StoredProcedure, new List<ParmStruct>{ new ParmStruct(@"id", iD, SqlDbType.BigInt) }) > 0;
        }

        public Item GetItem(int itemId)
        {
            Item item = new Item();
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>
                {
                    new ParmStruct("@itemId", itemId, SqlDbType.Int)
                };


                DataTable itemDetails = dal.Execute(SP_GET_ITEM, CommandType.StoredProcedure, parms);
                item.Name = itemDetails.Rows[0]["Name"].ToString();
                item.Description = itemDetails.Rows[0]["Description"].ToString();
                item.ID = Convert.ToInt32(itemDetails.Rows[0]["ID"]);
                item.Justification = itemDetails.Rows[0]["Justification"].ToString();
                item.Location = itemDetails.Rows[0]["Location"].ToString();
                item.Price = Convert.ToDecimal(itemDetails.Rows[0]["Price"]);
                item.Quantity = Convert.ToInt32(itemDetails.Rows[0]["Quantity"]);
                item.Status = (ItemStatus)itemDetails.Rows[0]["ItemStatusID"];
                item.TimeStamp = (byte[])itemDetails.Rows[0]["TimeStamp"];
                item.ModifyReason = itemDetails.Rows[0]["ModifyReason"].ToString();
                item.DenyReason = itemDetails.Rows[0]["DenyReason"].ToString();
                item.NoLongerNeeded = Convert.ToInt32(itemDetails.Rows[0]["IsNoLongerNeeded"]) > 0;
            }
            catch (Exception ex)
            {
                item.AddError(new Error(ex.Message));
            }
            return item;
        }

        public List<PurchaseOrder> GetOrders()
        {
            DataTable dt = dal.Execute(SP_GET_ORDERS, CommandType.StoredProcedure, null);
            List<PurchaseOrder> orders = new List<PurchaseOrder>();
            foreach (DataRow rw in dt.Rows)
            {
                PurchaseOrder order = new PurchaseOrder();
                order.ID = Convert.ToInt32(rw["ID"]);
                order.OrderDate = Convert.ToDateTime(rw["OrderDate"]);
                order.Status = (OrderStatus)rw["OrderStatusID"];
                order.Subtotal = Convert.ToDecimal(rw["Subtotal"]);
                order.Taxes = Convert.ToDecimal(rw["Taxes"]);
                order.Total = Convert.ToDecimal(rw["Total"]);
                order.TimeStamp = (byte[])rw["TimeStamp"];

                order.CreatedEmployee.ID = Convert.ToInt32(rw["EmployeeID"]);
                order.CreatedEmployee.FName = rw["FName"].ToString();
                order.CreatedEmployee.MName = rw["MName"].ToString();
                order.CreatedEmployee.LName = rw["LName"].ToString();
                order.CreatedEmployee.Departments = new Departments();
                order.CreatedEmployee.Departments.Name = rw["DepName"].ToString();
                order.CreatedEmployee.Departments.DepartmentID = Convert.ToInt32(rw["DepID"]);
                orders.Add(order);
            }
            return orders;
        }

        public PurchaseOrder GetOrder(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>
            {
                new ParmStruct("@orderID", id, SqlDbType.Int)
            };

            DataTable details = dal.Execute(SP_GET_ORDER_DETAILS, CommandType.StoredProcedure, parms);
            PurchaseOrder order = new PurchaseOrder();
            order.CreatedEmployee.ID = Convert.ToInt32(details.Rows[0]["EmployeeID"]);
            order.ID = Convert.ToInt32(details.Rows[0]["ID"]);
            order.OrderDate = Convert.ToDateTime(details.Rows[0]["OrderDate"]);
            order.Status = (OrderStatus)details.Rows[0]["OrderStatusID"];
            order.Subtotal = Convert.ToDecimal(details.Rows[0]["Subtotal"]);
            order.Taxes = Convert.ToDecimal(details.Rows[0]["Taxes"]);
            order.Total = Convert.ToDecimal(details.Rows[0]["Total"]);
            order.TimeStamp = (byte[])details.Rows[0]["TimeStamp"];

            order.CreatedEmployee = new Employee();
            order.CreatedEmployee.ID = Convert.ToInt32(details.Rows[0]["EmployeeID"]);
            order.CreatedEmployee.FName = details.Rows[0]["FName"].ToString();
            order.CreatedEmployee.MName = details.Rows[0]["MName"].ToString();
            order.CreatedEmployee.LName = details.Rows[0]["LName"].ToString();
            order.CreatedEmployee.Email = details.Rows[0]["Email"].ToString();
            order.CreatedEmployee.Departments = new Departments();
            order.CreatedEmployee.Departments.Name = details.Rows[0]["DepName"].ToString();
            order.CreatedEmployee.Departments.DepartmentID = Convert.ToInt32(details.Rows[0]["DepID"]);

            DataTable items = dal.Execute(SP_GET_ORDER_ITEMS, CommandType.StoredProcedure, parms);
            foreach (DataRow rw in items.Rows)
            {
                Item item = new Item();
                item.ID = Convert.ToInt32(rw["ID"]);
                item.Quantity = Convert.ToInt32(rw["Quantity"]);
                item.Price = Convert.ToDecimal(rw["Price"]);
                item.Status = (ItemStatus)rw["ItemStatusID"];
                item.Name = rw["Name"].ToString();
                item.Description = rw["Description"].ToString();
                item.Justification = rw["Justification"].ToString();
                item.Location = rw["Location"].ToString();
                item.ModifyReason = rw["ModifyReason"].ToString();
                item.DenyReason = rw["DenyReason"].ToString();
                item.TimeStamp = (byte[])rw["TimeStamp"];
                item.NoLongerNeeded = Convert.ToInt32(rw["IsNoLongerNeeded"]) > 0;

                order.AddItem(item);
            }

            return order;
        }

        public bool ModifyItem(Item item)
        {
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@itemID", item.ID, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@name", item.Name, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@desc", item.Description, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@qty", item.Quantity, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@price", item.Price, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@subtotal", item.Subtotal, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@justification", item.Justification, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@location", item.Location, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@status", item.Status, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@modifyReason", item.ModifyReason, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@denyReason", item.DenyReason, System.Data.SqlDbType.VarChar));
                parms.Add(new ParmStruct("@isNoLongerNeeded", item.NoLongerNeeded ? 1 : 0, System.Data.SqlDbType.Bit));
                parms.Add(new ParmStruct("@timeStamp", item.TimeStamp, System.Data.SqlDbType.Timestamp, ParameterDirection.InputOutput));

                int updateSuccess = dal.ExecuteNonQuery(SP_MODIFY_ITEM, System.Data.CommandType.StoredProcedure, parms);
                if(updateSuccess > 0)
                {
                    item.TimeStamp = (byte[])parms.Last().Value;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                item.AddError(new Error(ex.Message));
                return false;
            }
        }

        public bool ModifyOrder(PurchaseOrder order)
        {
            try
            {
                List<ParmStruct> parms = new List<ParmStruct>();
                parms.Add(new ParmStruct("@orderID", order.ID, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@subtotal", order.Subtotal, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@taxes", order.Taxes, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@total", order.Total, System.Data.SqlDbType.Money));
                parms.Add(new ParmStruct("@status", (int)order.Status, System.Data.SqlDbType.Int));
                parms.Add(new ParmStruct("@timeStamp", order.TimeStamp, System.Data.SqlDbType.Timestamp, ParameterDirection.InputOutput));

                int updateSuccess = dal.ExecuteNonQuery(SP_MODIFY_ORDER, System.Data.CommandType.StoredProcedure, parms);
                if (updateSuccess > 0) order.TimeStamp = (byte[])parms.Last().Value;
                return updateSuccess > 0;
            }
            catch (Exception ex)
            {
                order.AddError(new Error(ex.Message));
                return false;
            }
        }
    }
}
