using BLL;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1InputPanel;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopValue
{
    public partial class POMainForm : C1.Win.Ribbon.C1RibbonForm
    {
        private User user;
        private PurchaseOrder po = new PurchaseOrder();
        private Item currentItem;
        private OrderBL orderBL = new OrderBL();
        private bool itemValid = false;
        private Main main;
        public POMainForm(Main mainForm, User u)
        {
            InitializeComponent();
            main = mainForm;
            user = u;
        }

        #region Tabs

        private void POMainForm_Load(object sender, EventArgs e)
        {
            SetUpFlexGrid();
            currentUserBindingSource.DataSource = user;

            lblBrowseType.Text = user.IsSupervisor ? "Browse Purchase Orders for Processing / Modifying" : "Browse Purchase Orders for Modifying";
            lblSearchType.Text = user.IsSupervisor ? "To search by PO Number or Employee Name input search criteria in the textbox below" : "To search by PO Number input search criteria in the textbox below";
            cboItemStatus.ItemsDataSource = Enum.GetValues(typeof(ItemStatus));
        }
        private void SetUpFlexGrid()
        {
            SortableBindingList<PurchaseOrder> list = new SortableBindingList<PurchaseOrder>();
            orderBL.RetrieveOrdersForEmployee(user).ForEach(o => list.Add(o));
            purchaseOrderBindingSource.DataSource = list;

            //bug so styles are not loaded
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POMainForm));
            this.gridPurchaseOrders.ColumnInfo = resources.GetString("gridPurchaseOrders.ColumnInfo");
            this.gridPurchaseOrders.StyleInfo = resources.GetString("gridPurchaseOrders.StyleInfo");

            //Check if user is supervisor then sort by oldest first
            if (user.IsSupervisor) this.gridPurchaseOrders.Sort(SortFlags.Ascending, 5);
            else this.gridPurchaseOrders.Sort(SortFlags.Descending, 5);
        }
        private void gridPurchaseOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ht = gridPurchaseOrders.HitTest();

            if (ht.Row > 0)
            {
                po = orderBL.RetrieveOrder(Convert.ToInt32(gridPurchaseOrders[ht.Row, 1]));
                tabMaintainPO.Show();
                tabMaintainPO.Text = "Modify Purchase Order";
                tabMaintainPO.Focus();
            }
        }

        private void tabMaintainPO_Leave(object sender, EventArgs e)
        {
            po = new PurchaseOrder();
            po.CreatedEmployee = user;
        }
        private void tabMaintainPO_Enter(object sender, EventArgs e)
        {
            if (po.CreatedEmployee.FName == null) po.CreatedEmployee = user;

            //Setting up datasources
            itemBindingSource.DataSource = po.Items;
            purchaseOrderBindingSource.DataSource = po;
            purchaseOrderBindingSource.CurrencyManager.Refresh();
        }
        private void browsePOTab_Enter(object sender, EventArgs e)
        {
            SetUpFlexGrid();

            //Reset PO
            tabMaintainPO.Text = "Create Purchase Order";
            tabMaintainPO.Enabled = true;
        }

        #endregion

        #region Maintain PO Tab

        #region Navigator Buttons

        private void bindingNavigatorNoLongerNeeded_Click(object sender, EventArgs e)
        {
            orderBL.RemoveItem(currentItem, po, user);
            itemBindingSource.CurrencyManager.Refresh();
            purchaseOrderBindingSource.CurrencyManager.Refresh();
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            EnableFeatures();
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            EnableFeatures();
        }
        private void bindingNavigatorCloseOrder_Click(object sender, EventArgs e)
        {
            if (orderBL.CloseOrder(po)) MessageBox.Show(this, $"Order with ID: {po.ID} was successfully closed. Email Notification has been sent to the user at {po.CreatedEmployee.Email}", "Closed Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show(this, "Something went wrong");
            EnableFeatures();
            this.purchaseOrderBindingSource.CurrencyManager.Refresh();
            EnableFeatures();
        }

        #endregion

        #region Binding Sources

        private void itemBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            currentItem = (Item)itemBindingNavigator.BindingSource.Current;
            EnableFeatures();
        }
        private void purchaseOrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            EnableFeatures();
        }

        #endregion


        #region Maintain PO

        private void Item_Validated(object sender, EventArgs e)
        {
            itemValid = currentItem != null && currentItem.Errors.Count == 0;

            Maintain();
            EnableFeatures();
        }
        private void Maintain()
        {
            //Mainttain po - init and modify and process

            if (!itemValid) return;

            if (po.Items.Count > 0 && po.ID != 0) Modify();
            else if (po.Items.Count > 0 && po.ID == 0) InitPO();

            //to fix empty rows bug
            gridPOItems.Update();
            gridPOItems.DataSource = null;
            gridPOItems.DataSource = itemBindingSource;

            purchaseOrderBindingSource.CurrencyManager.Refresh();
            itemBindingSource.CurrencyManager.Refresh();
        }
        private void InitPO()
        {
            po.CreatedEmployee = user;
            if (!orderBL.InitPORequest(po))
            {
                po.Errors.ForEach(e => MessageBox.Show(this, e.ErrorName, e.ErrorDescription, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            }
        }
        private void Modify()
        {
            if (!orderBL.ModifyOrder(po))
            {
                po.Errors.ForEach(e => MessageBox.Show(this, e.ErrorName, e.ErrorDescription, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            }
            this.itemBindingSource.CurrencyManager.Refresh();
        }

        #endregion


        private void cboItemStatus_SelectedItemChanged(object sender, EventArgs e)
        {
            //closing notification popup
            if (currentItem != null && cboItemStatus.SelectedItem != null)
            {
                currentItem.Status = (ItemStatus)cboItemStatus.SelectedItem;
                if (currentItem.Status != ItemStatus.Denied)
                {
                    cboItemStatus.Text = currentItem.Status.ToString();
                    this.purchaseOrderBindingSource.CurrencyManager.Refresh();
                    if (orderBL.CanBeClosed(po, user))
                    {
                        DialogResult result = MessageBox.Show(this, $"Purchase Order #{po.ID} can be closed. Would you like to do that? You can always close it later, the button will be in the top menu.", $"Purchase Order #{po.ID} can be closed", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            if (orderBL.CloseOrder(po))
                                MessageBox.Show(this, $"Order with ID: {po.ID} was successfully closed. Email Notification has been sent to the user at {po.CreatedEmployee.Email}", "Closed Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show(this, "Email was not send and the Purchase Order wasn't closed. Something went wrong. Please retry and refresh data");
                        }
                    }
                }
            }

        }
        private void EnableFeatures()
        {
            //Disable some functionality accroding to business rules

            tabMaintainPO.Enabled = !orderBL.CheckIfOrderClosed(po);
            grpPOInfo.Visible = po.ID > 0;
            grpProcess.Visible = orderBL.CanBeProcessed(po, user, currentItem) && currentItem != null && !currentItem.NoLongerNeeded;
            bindingNavigatorDeleteItem.Visible = po.ID == 0 || currentItem.ID == 0 && !itemValid;
            bindingNavigatorCloseOrder.Visible = orderBL.CanBeClosed(po, user);
            bindingNavigatorNoLongerNeeded.Visible = currentItem != null && currentItem.ID != 0 && !currentItem.NoLongerNeeded && !orderBL.RestrictedModifyMode(po, user) ? true : false;
            grpTotals.Visible = po.ID > 0;
            gridPOItems.Visible = po.ID > 0;
            lblPoAction.Text = po.ID > 0 ? "Modify PO" : "Create PO";
            lblPoAction.Text = orderBL.CheckIfOrderClosed(po) ? $"Order Was Closed. Closing Notification was sent to {po.CreatedEmployee.Email}" : lblPoAction.Text;
            grpItemInfo.Enabled = !currentItem?.NoLongerNeeded ?? true;
            bindingNavigatorAddNewItem.Visible = orderBL.CanAddItems(po, user);
            lblDenyReason.Visible = currentItem != null && currentItem.Status == ItemStatus.Denied;
            txtDenyReason.Visible = currentItem != null && currentItem.Status == ItemStatus.Denied;
            lblItemsForPO.Visible = po.ID > 0;

            if (orderBL.RestrictedModifyMode(po, user))
            {
                txtName.Enabled = false;
                txtDesc.Enabled = false;
                txtJusitifcation.Enabled = false;
                txtModifyReason.Visible = true;
                lblModifyReason.Visible = true;
                txtQuantity.Enabled = currentItem.ModifyReason != "";
                txtPrice.Enabled = currentItem.ModifyReason != "";
                txtLocation.Enabled = currentItem.ModifyReason != "";
            }

            //set up flex grid
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POMainForm));
            gridPOItems.ColumnInfo = resources.GetString("gridPOItems.ColumnInfo");
            gridPOItems.StyleInfo = resources.GetString("gridPOItems.StyleInfo");
            gridPOItems.AutoSizeCols();
        }
        #endregion

        private void POMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            po = null;
        }
    }
}