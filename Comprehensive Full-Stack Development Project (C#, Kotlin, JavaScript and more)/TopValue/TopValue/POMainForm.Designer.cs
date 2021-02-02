using System;

namespace TopValue
{
    partial class POMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Themes.C1MaterialThemeSettings c1MaterialThemeSettings5 = new C1.Win.C1Themes.C1MaterialThemeSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POMainForm));
            C1.Win.C1Themes.C1MaterialThemeSettings c1MaterialThemeSettings6 = new C1.Win.C1Themes.C1MaterialThemeSettings();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.browsePOTab = new C1.Win.C1Command.C1DockingTabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.lblBrowseType = new System.Windows.Forms.Label();
            this.c1FlexGridSearchPanel1 = new C1.Win.C1FlexGrid.C1FlexGridSearchPanel();
            this.gridPurchaseOrders = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.purchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabMaintainPO = new C1.Win.C1Command.C1DockingTabPage();
            this.lblPoAction = new System.Windows.Forms.Label();
            this.grpProcess = new System.Windows.Forms.GroupBox();
            this.txtDenyReason = new C1.Win.C1Input.C1TextBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboItemStatus = new C1.Win.C1Input.C1ComboBox();
            this.lblDenyReason = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPOTotal = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPOSubtotal = new C1.Win.C1Input.C1TextBox();
            this.txtPOTax = new C1.Win.C1Input.C1TextBox();
            this.gridPOItems = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grpItemInfo = new System.Windows.Forms.GroupBox();
            this.txtModifyReason = new C1.Win.C1Input.C1TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtPrice = new C1.Win.C1Input.C1TextBox();
            this.lblModifyReason = new System.Windows.Forms.Label();
            this.lblJustification = new System.Windows.Forms.Label();
            this.txtLocation = new C1.Win.C1Input.C1TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtQuantity = new C1.Win.C1Input.C1TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtJusitifcation = new C1.Win.C1Input.C1TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtName = new C1.Win.C1Input.C1TextBox();
            this.txtDesc = new C1.Win.C1Input.C1TextBox();
            this.grpPOInfo = new System.Windows.Forms.GroupBox();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.txtOrderStatus = new C1.Win.C1Input.C1TextBox();
            this.txtOrderID = new C1.Win.C1Input.C1TextBox();
            this.txtOrderDate = new C1.Win.C1Input.C1TextBox();
            this.grpEmployeeInfo = new System.Windows.Forms.GroupBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSupervisorName = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.txtDepartmentName = new C1.Win.C1Input.C1TextBox();
            this.currentUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSupName = new C1.Win.C1Input.C1TextBox();
            this.txtEmpName = new C1.Win.C1Input.C1TextBox();
            this.itemBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorNoLongerNeeded = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCloseOrder = new System.Windows.Forms.ToolStripLabel();
            this.c1SuperErrorProvider1 = new C1.Win.C1SuperTooltip.C1SuperErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c1Label16 = new C1.Win.C1Input.C1Label();
            this.c1Label17 = new C1.Win.C1Input.C1Label();
            this.c1Label18 = new C1.Win.C1Input.C1Label();
            this.c1TextBox2 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox3 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox4 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.lblItemsForPO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.browsePOTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).BeginInit();
            this.tabMaintainPO.SuspendLayout();
            this.grpProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenyReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemStatus)).BeginInit();
            this.grpTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).BeginInit();
            this.grpItemInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifyReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJusitifcation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            this.grpPOInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate)).BeginInit();
            this.grpEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingNavigator)).BeginInit();
            this.itemBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1ThemeController1
            // 
            this.c1ThemeController1.Theme = "Material";
            c1MaterialThemeSettings5.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            c1MaterialThemeSettings5.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.c1ThemeController1.ThemeSettings = c1MaterialThemeSettings5;
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.BackColor = System.Drawing.Color.White;
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1DockingTab1.Controls.Add(this.browsePOTab);
            this.c1DockingTab1.Controls.Add(this.tabMaintainPO);
            this.c1DockingTab1.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1DockingTab1.HotTrack = true;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 12);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.SelectedIndex = 1;
            this.c1DockingTab1.Size = new System.Drawing.Size(2450, 1250);
            this.c1DockingTab1.TabIndex = 1;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsShowFocusCues = false;
            this.c1DockingTab1.TabsSpacing = 2;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.c1ThemeController1.SetTheme(this.c1DockingTab1, "(default)");
            // 
            // browsePOTab
            // 
            this.browsePOTab.Controls.Add(this.label6);
            this.browsePOTab.Controls.Add(this.label8);
            this.browsePOTab.Controls.Add(this.lblSearchType);
            this.browsePOTab.Controls.Add(this.lblBrowseType);
            this.browsePOTab.Controls.Add(this.c1FlexGridSearchPanel1);
            this.browsePOTab.Controls.Add(this.gridPurchaseOrders);
            this.browsePOTab.Location = new System.Drawing.Point(1, 43);
            this.browsePOTab.Name = "browsePOTab";
            this.browsePOTab.Size = new System.Drawing.Size(2448, 1206);
            this.browsePOTab.TabIndex = 1;
            this.browsePOTab.Text = "Browse Purchase Orders";
            this.browsePOTab.Enter += new System.EventHandler(this.browsePOTab_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label6.Location = new System.Drawing.Point(627, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(605, 31);
            this.label6.TabIndex = 4;
            this.label6.Text = "(To Modify PO - Double Click On Desired One in the Table)";
            this.c1ThemeController1.SetTheme(this.label6, "(default)");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label8.Location = new System.Drawing.Point(287, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1395, 38);
            this.label8.TabIndex = 4;
            this.label8.Text = "To search by Date Ranges, PO Status and more apply filters using the icon in the " +
    "right corner of desired column";
            this.c1ThemeController1.SetTheme(this.label8, "(default)");
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSearchType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblSearchType.Location = new System.Drawing.Point(387, 120);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(1084, 38);
            this.lblSearchType.TabIndex = 3;
            this.lblSearchType.Text = "To search by PO Number or Employee Name input search criteria in the textbox belo" +
    "w";
            this.c1ThemeController1.SetTheme(this.lblSearchType, "(default)");
            // 
            // lblBrowseType
            // 
            this.lblBrowseType.AutoSize = true;
            this.lblBrowseType.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrowseType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblBrowseType.Location = new System.Drawing.Point(625, 23);
            this.lblBrowseType.Name = "lblBrowseType";
            this.lblBrowseType.Size = new System.Drawing.Size(557, 48);
            this.lblBrowseType.TabIndex = 2;
            this.lblBrowseType.Text = "Search and Browse PO Requests";
            this.c1ThemeController1.SetTheme(this.lblBrowseType, "(default)");
            // 
            // c1FlexGridSearchPanel1
            // 
            this.c1FlexGridSearchPanel1.Location = new System.Drawing.Point(14, 205);
            this.c1FlexGridSearchPanel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.c1FlexGridSearchPanel1.Name = "c1FlexGridSearchPanel1";
            this.c1FlexGridSearchPanel1.SearchDelay = 1;
            this.c1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always;
            this.c1FlexGridSearchPanel1.ShowClearButton = false;
            this.c1FlexGridSearchPanel1.ShowSearchButton = false;
            this.c1FlexGridSearchPanel1.Size = new System.Drawing.Size(1882, 74);
            this.c1FlexGridSearchPanel1.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.c1FlexGridSearchPanel1, "(default)");
            // 
            // gridPurchaseOrders
            // 
            this.gridPurchaseOrders.AllowEditing = false;
            this.gridPurchaseOrders.AllowFiltering = true;
            this.gridPurchaseOrders.BackColor = System.Drawing.Color.White;
            this.c1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(this.gridPurchaseOrders, this.c1FlexGridSearchPanel1);
            this.gridPurchaseOrders.ColumnInfo = resources.GetString("gridPurchaseOrders.ColumnInfo");
            this.gridPurchaseOrders.DataSource = this.purchaseOrderBindingSource;
            this.gridPurchaseOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.gridPurchaseOrders.Location = new System.Drawing.Point(23, 401);
            this.gridPurchaseOrders.Name = "gridPurchaseOrders";
            this.gridPurchaseOrders.Rows.Count = 1;
            this.gridPurchaseOrders.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.gridPurchaseOrders.Size = new System.Drawing.Size(1873, 480);
            this.gridPurchaseOrders.StyleInfo = resources.GetString("gridPurchaseOrders.StyleInfo");
            this.gridPurchaseOrders.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.gridPurchaseOrders, "(default)");
            this.gridPurchaseOrders.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.gridPurchaseOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridPurchaseOrders_MouseDoubleClick);
            // 
            // purchaseOrderBindingSource
            // 
            this.purchaseOrderBindingSource.DataSource = typeof(Model.Entities.PurchaseOrder);
            this.purchaseOrderBindingSource.CurrentChanged += new System.EventHandler(this.purchaseOrderBindingSource_CurrentChanged);
            // 
            // tabMaintainPO
            // 
            this.tabMaintainPO.Controls.Add(this.lblItemsForPO);
            this.tabMaintainPO.Controls.Add(this.lblPoAction);
            this.tabMaintainPO.Controls.Add(this.grpProcess);
            this.tabMaintainPO.Controls.Add(this.grpTotals);
            this.tabMaintainPO.Controls.Add(this.gridPOItems);
            this.tabMaintainPO.Controls.Add(this.grpItemInfo);
            this.tabMaintainPO.Controls.Add(this.grpPOInfo);
            this.tabMaintainPO.Controls.Add(this.grpEmployeeInfo);
            this.tabMaintainPO.Controls.Add(this.itemBindingNavigator);
            this.tabMaintainPO.Location = new System.Drawing.Point(1, 43);
            this.tabMaintainPO.Name = "tabMaintainPO";
            this.tabMaintainPO.Size = new System.Drawing.Size(2448, 1206);
            this.tabMaintainPO.TabIndex = 0;
            this.tabMaintainPO.Text = "Create Purchase Order";
            this.tabMaintainPO.Enter += new System.EventHandler(this.tabMaintainPO_Enter);
            this.tabMaintainPO.Leave += new System.EventHandler(this.tabMaintainPO_Leave);
            // 
            // lblPoAction
            // 
            this.lblPoAction.AutoSize = true;
            this.lblPoAction.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblPoAction.Location = new System.Drawing.Point(25, 62);
            this.lblPoAction.Name = "lblPoAction";
            this.lblPoAction.Size = new System.Drawing.Size(147, 38);
            this.lblPoAction.TabIndex = 16;
            this.lblPoAction.Text = "Create PO";
            this.c1ThemeController1.SetTheme(this.lblPoAction, "(default)");
            // 
            // grpProcess
            // 
            this.grpProcess.BackColor = System.Drawing.Color.White;
            this.grpProcess.Controls.Add(this.txtDenyReason);
            this.grpProcess.Controls.Add(this.cboItemStatus);
            this.grpProcess.Controls.Add(this.lblDenyReason);
            this.grpProcess.Controls.Add(this.label5);
            this.grpProcess.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.grpProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.grpProcess.Location = new System.Drawing.Point(32, 519);
            this.grpProcess.Name = "grpProcess";
            this.grpProcess.Size = new System.Drawing.Size(743, 248);
            this.grpProcess.TabIndex = 2;
            this.grpProcess.TabStop = false;
            this.grpProcess.Text = "Process Item";
            this.c1ThemeController1.SetTheme(this.grpProcess, "(default)");
            // 
            // txtDenyReason
            // 
            this.txtDenyReason.AutoSize = false;
            this.txtDenyReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtDenyReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenyReason.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "DenyReason", true));
            this.txtDenyReason.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtDenyReason.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtDenyReason.Location = new System.Drawing.Point(274, 151);
            this.txtDenyReason.Name = "txtDenyReason";
            this.txtDenyReason.Padding = new System.Windows.Forms.Padding(4);
            this.txtDenyReason.Size = new System.Drawing.Size(280, 80);
            this.txtDenyReason.TabIndex = 31;
            this.txtDenyReason.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtDenyReason, "(default)");
            this.txtDenyReason.Visible = false;
            this.txtDenyReason.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtDenyReason.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(Model.Entities.Item);
            this.itemBindingSource.CurrentChanged += new System.EventHandler(this.itemBindingSource_CurrentChanged);
            // 
            // cboItemStatus
            // 
            this.cboItemStatus.AllowSpinLoop = false;
            this.cboItemStatus.AutoSize = false;
            this.cboItemStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.cboItemStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboItemStatus.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Status", true));
            this.cboItemStatus.DataType = typeof(Model.ItemStatus);
            this.cboItemStatus.DisabledForeColor = System.Drawing.Color.Gray;
            this.cboItemStatus.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.cboItemStatus.GapHeight = 0;
            this.cboItemStatus.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboItemStatus.ItemsDisplayMember = "";
            this.cboItemStatus.ItemsValueMember = "";
            this.cboItemStatus.Location = new System.Drawing.Point(274, 50);
            this.cboItemStatus.Name = "cboItemStatus";
            this.cboItemStatus.Padding = new System.Windows.Forms.Padding(4);
            this.cboItemStatus.Size = new System.Drawing.Size(280, 80);
            this.cboItemStatus.Style.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.cboItemStatus.TabIndex = 24;
            this.cboItemStatus.Tag = null;
            this.c1ThemeController1.SetTheme(this.cboItemStatus, "(default)");
            this.cboItemStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cboItemStatus.SelectedItemChanged += new System.EventHandler(this.cboItemStatus_SelectedItemChanged);
            this.cboItemStatus.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblDenyReason
            // 
            this.lblDenyReason.AutoSize = true;
            this.lblDenyReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblDenyReason.Location = new System.Drawing.Point(35, 157);
            this.lblDenyReason.Name = "lblDenyReason";
            this.lblDenyReason.Size = new System.Drawing.Size(212, 31);
            this.lblDenyReason.TabIndex = 29;
            this.lblDenyReason.Text = "Reason for Denying";
            this.c1ThemeController1.SetTheme(this.lblDenyReason, "(default)");
            this.lblDenyReason.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label5.Location = new System.Drawing.Point(35, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 31);
            this.label5.TabIndex = 29;
            this.label5.Text = "Item Status";
            this.c1ThemeController1.SetTheme(this.label5, "(default)");
            // 
            // grpTotals
            // 
            this.grpTotals.BackColor = System.Drawing.Color.White;
            this.grpTotals.Controls.Add(this.label1);
            this.grpTotals.Controls.Add(this.label3);
            this.grpTotals.Controls.Add(this.txtPOTotal);
            this.grpTotals.Controls.Add(this.label2);
            this.grpTotals.Controls.Add(this.txtPOSubtotal);
            this.grpTotals.Controls.Add(this.txtPOTax);
            this.grpTotals.Enabled = false;
            this.grpTotals.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.grpTotals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.grpTotals.Location = new System.Drawing.Point(1473, 470);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(688, 307);
            this.grpTotals.TabIndex = 14;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Totals";
            this.c1ThemeController1.SetTheme(this.grpTotals, "(default)");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label1.Location = new System.Drawing.Point(35, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 31);
            this.label1.TabIndex = 30;
            this.label1.Text = "Subtotal";
            this.c1ThemeController1.SetTheme(this.label1, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label3.Location = new System.Drawing.Point(35, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 31);
            this.label3.TabIndex = 28;
            this.label3.Text = "Total";
            this.c1ThemeController1.SetTheme(this.label3, "(default)");
            // 
            // txtPOTotal
            // 
            this.txtPOTotal.AutoSize = false;
            this.txtPOTotal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtPOTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPOTotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.Never, "", "$#,00.00"));
            this.txtPOTotal.DataType = typeof(decimal);
            this.txtPOTotal.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtPOTotal.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPOTotal.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtPOTotal.Location = new System.Drawing.Point(241, 218);
            this.txtPOTotal.Multiline = true;
            this.txtPOTotal.Name = "txtPOTotal";
            this.txtPOTotal.Padding = new System.Windows.Forms.Padding(4);
            this.txtPOTotal.Size = new System.Drawing.Size(280, 80);
            this.txtPOTotal.TabIndex = 16;
            this.txtPOTotal.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtPOTotal, "(default)");
            this.txtPOTotal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label2.Location = new System.Drawing.Point(34, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 31);
            this.label2.TabIndex = 29;
            this.label2.Text = "Sales Tax";
            this.c1ThemeController1.SetTheme(this.label2, "(default)");
            // 
            // txtPOSubtotal
            // 
            this.txtPOSubtotal.AutoSize = false;
            this.txtPOSubtotal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtPOSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPOSubtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "Subtotal", true, System.Windows.Forms.DataSourceUpdateMode.Never, "", "$#,00.00"));
            this.txtPOSubtotal.DataType = typeof(decimal);
            this.txtPOSubtotal.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtPOSubtotal.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPOSubtotal.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtPOSubtotal.Location = new System.Drawing.Point(241, 63);
            this.txtPOSubtotal.Multiline = true;
            this.txtPOSubtotal.Name = "txtPOSubtotal";
            this.txtPOSubtotal.Padding = new System.Windows.Forms.Padding(4);
            this.txtPOSubtotal.Size = new System.Drawing.Size(280, 80);
            this.txtPOSubtotal.TabIndex = 13;
            this.txtPOSubtotal.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtPOSubtotal, "(default)");
            this.txtPOSubtotal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtPOTax
            // 
            this.txtPOTax.AutoSize = false;
            this.txtPOTax.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtPOTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPOTax.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "Taxes", true, System.Windows.Forms.DataSourceUpdateMode.Never, "", "$#,00.00"));
            this.txtPOTax.DataType = typeof(decimal);
            this.txtPOTax.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtPOTax.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPOTax.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtPOTax.Location = new System.Drawing.Point(241, 138);
            this.txtPOTax.Multiline = true;
            this.txtPOTax.Name = "txtPOTax";
            this.txtPOTax.Padding = new System.Windows.Forms.Padding(4);
            this.txtPOTax.Size = new System.Drawing.Size(280, 80);
            this.txtPOTax.TabIndex = 15;
            this.txtPOTax.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtPOTax, "(default)");
            this.txtPOTax.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // gridPOItems
            // 
            this.gridPOItems.AllowEditing = false;
            this.gridPOItems.BackColor = System.Drawing.Color.White;
            this.gridPOItems.ColumnInfo = resources.GetString("gridPOItems.ColumnInfo");
            this.gridPOItems.DataSource = this.itemBindingSource;
            this.gridPOItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.gridPOItems.Location = new System.Drawing.Point(32, 884);
            this.gridPOItems.Name = "gridPOItems";
            this.gridPOItems.Rows.Count = 1;
            this.gridPOItems.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.gridPOItems.Size = new System.Drawing.Size(2374, 309);
            this.gridPOItems.StyleInfo = resources.GetString("gridPOItems.StyleInfo");
            this.gridPOItems.TabIndex = 15;
            this.c1ThemeController1.SetTheme(this.gridPOItems, "(default)");
            this.gridPOItems.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            // 
            // grpItemInfo
            // 
            this.grpItemInfo.BackColor = System.Drawing.Color.White;
            this.grpItemInfo.Controls.Add(this.txtModifyReason);
            this.grpItemInfo.Controls.Add(this.lblName);
            this.grpItemInfo.Controls.Add(this.lblDesc);
            this.grpItemInfo.Controls.Add(this.txtPrice);
            this.grpItemInfo.Controls.Add(this.lblModifyReason);
            this.grpItemInfo.Controls.Add(this.lblJustification);
            this.grpItemInfo.Controls.Add(this.txtLocation);
            this.grpItemInfo.Controls.Add(this.lblLocation);
            this.grpItemInfo.Controls.Add(this.txtQuantity);
            this.grpItemInfo.Controls.Add(this.lblQuantity);
            this.grpItemInfo.Controls.Add(this.txtJusitifcation);
            this.grpItemInfo.Controls.Add(this.lblPrice);
            this.grpItemInfo.Controls.Add(this.txtName);
            this.grpItemInfo.Controls.Add(this.txtDesc);
            this.grpItemInfo.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.grpItemInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.grpItemInfo.Location = new System.Drawing.Point(805, 128);
            this.grpItemInfo.Name = "grpItemInfo";
            this.grpItemInfo.Size = new System.Drawing.Size(635, 649);
            this.grpItemInfo.TabIndex = 14;
            this.grpItemInfo.TabStop = false;
            this.grpItemInfo.Text = "Item Information";
            this.c1ThemeController1.SetTheme(this.grpItemInfo, "(default)");
            // 
            // txtModifyReason
            // 
            this.txtModifyReason.AutoSize = false;
            this.txtModifyReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtModifyReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModifyReason.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "ModifyReason", true));
            this.txtModifyReason.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtModifyReason.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtModifyReason.Location = new System.Drawing.Point(274, 552);
            this.txtModifyReason.Name = "txtModifyReason";
            this.txtModifyReason.Padding = new System.Windows.Forms.Padding(4);
            this.txtModifyReason.Size = new System.Drawing.Size(300, 100);
            this.txtModifyReason.TabIndex = 30;
            this.txtModifyReason.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtModifyReason, "(default)");
            this.txtModifyReason.Visible = false;
            this.txtModifyReason.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtModifyReason.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblName.Location = new System.Drawing.Point(34, 73);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(127, 31);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Item Name";
            this.c1ThemeController1.SetTheme(this.lblName, "(default)");
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblDesc.Location = new System.Drawing.Point(31, 145);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(183, 31);
            this.lblDesc.TabIndex = 23;
            this.lblDesc.Text = "Item Description";
            this.c1ThemeController1.SetTheme(this.lblDesc, "(default)");
            // 
            // txtPrice
            // 
            this.txtPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Price", true));
            this.txtPrice.DataType = typeof(decimal);
            this.txtPrice.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtPrice.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtPrice.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtPrice.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency;
            this.txtPrice.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtPrice.Location = new System.Drawing.Point(274, 457);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Padding = new System.Windows.Forms.Padding(4);
            this.txtPrice.Size = new System.Drawing.Size(300, 100);
            this.txtPrice.TabIndex = 22;
            this.txtPrice.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtPrice, "Material");
            c1MaterialThemeSettings6.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            c1MaterialThemeSettings6.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.c1ThemeController1.SetThemeSettings(this.txtPrice, c1MaterialThemeSettings6);
            this.txtPrice.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtPrice.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblModifyReason
            // 
            this.lblModifyReason.AutoSize = true;
            this.lblModifyReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblModifyReason.Location = new System.Drawing.Point(34, 566);
            this.lblModifyReason.Name = "lblModifyReason";
            this.lblModifyReason.Size = new System.Drawing.Size(232, 31);
            this.lblModifyReason.TabIndex = 29;
            this.lblModifyReason.Text = "Reason for Modifying";
            this.c1ThemeController1.SetTheme(this.lblModifyReason, "(default)");
            this.lblModifyReason.Visible = false;
            // 
            // lblJustification
            // 
            this.lblJustification.AutoSize = true;
            this.lblJustification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblJustification.Location = new System.Drawing.Point(34, 225);
            this.lblJustification.Name = "lblJustification";
            this.lblJustification.Size = new System.Drawing.Size(187, 31);
            this.lblJustification.TabIndex = 24;
            this.lblJustification.Text = "Item Justification";
            this.c1ThemeController1.SetTheme(this.lblJustification, "(default)");
            // 
            // txtLocation
            // 
            this.txtLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Location", true));
            this.txtLocation.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtLocation.Location = new System.Drawing.Point(274, 295);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Padding = new System.Windows.Forms.Padding(4);
            this.txtLocation.Size = new System.Drawing.Size(300, 100);
            this.txtLocation.TabIndex = 20;
            this.txtLocation.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtLocation, "(default)");
            this.txtLocation.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtLocation.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblLocation.Location = new System.Drawing.Point(37, 301);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(153, 31);
            this.lblLocation.TabIndex = 25;
            this.lblLocation.Text = "Item Location";
            this.c1ThemeController1.SetTheme(this.lblLocation, "(default)");
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Quantity", true));
            this.txtQuantity.DataType = typeof(int);
            this.txtQuantity.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtQuantity.Location = new System.Drawing.Point(274, 375);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Padding = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Size = new System.Drawing.Size(300, 100);
            this.txtQuantity.TabIndex = 21;
            this.txtQuantity.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtQuantity, "(default)");
            this.txtQuantity.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtQuantity.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblQuantity.Location = new System.Drawing.Point(34, 391);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(154, 31);
            this.lblQuantity.TabIndex = 26;
            this.lblQuantity.Text = "Item Quantity";
            this.c1ThemeController1.SetTheme(this.lblQuantity, "(default)");
            // 
            // txtJusitifcation
            // 
            this.txtJusitifcation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtJusitifcation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJusitifcation.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Justification", true));
            this.txtJusitifcation.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtJusitifcation.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtJusitifcation.Location = new System.Drawing.Point(274, 215);
            this.txtJusitifcation.Multiline = true;
            this.txtJusitifcation.Name = "txtJusitifcation";
            this.txtJusitifcation.Padding = new System.Windows.Forms.Padding(4);
            this.txtJusitifcation.Size = new System.Drawing.Size(300, 100);
            this.txtJusitifcation.TabIndex = 16;
            this.txtJusitifcation.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtJusitifcation, "(default)");
            this.txtJusitifcation.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtJusitifcation.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblPrice.Location = new System.Drawing.Point(34, 470);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(116, 31);
            this.lblPrice.TabIndex = 27;
            this.lblPrice.Text = "Item Price";
            this.c1ThemeController1.SetTheme(this.lblPrice, "(default)");
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Name", true));
            this.txtName.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtName.Location = new System.Drawing.Point(274, 64);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(4);
            this.txtName.Size = new System.Drawing.Size(300, 100);
            this.txtName.TabIndex = 13;
            this.txtName.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtName, "(default)");
            this.txtName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtName.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // txtDesc
            // 
            this.txtDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.itemBindingSource, "Description", true));
            this.txtDesc.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtDesc.Location = new System.Drawing.Point(274, 139);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Padding = new System.Windows.Forms.Padding(4);
            this.txtDesc.Size = new System.Drawing.Size(300, 100);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtDesc, "(default)");
            this.txtDesc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtDesc.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // grpPOInfo
            // 
            this.grpPOInfo.BackColor = System.Drawing.Color.White;
            this.grpPOInfo.Controls.Add(this.lblOrderStatus);
            this.grpPOInfo.Controls.Add(this.label4);
            this.grpPOInfo.Controls.Add(this.lblOrderDate);
            this.grpPOInfo.Controls.Add(this.txtOrderStatus);
            this.grpPOInfo.Controls.Add(this.txtOrderID);
            this.grpPOInfo.Controls.Add(this.txtOrderDate);
            this.grpPOInfo.Enabled = false;
            this.grpPOInfo.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.grpPOInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.grpPOInfo.Location = new System.Drawing.Point(1473, 128);
            this.grpPOInfo.Name = "grpPOInfo";
            this.grpPOInfo.Size = new System.Drawing.Size(688, 307);
            this.grpPOInfo.TabIndex = 10;
            this.grpPOInfo.TabStop = false;
            this.grpPOInfo.Text = "PO Information";
            this.c1ThemeController1.SetTheme(this.grpPOInfo, "(default)");
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblOrderStatus.Location = new System.Drawing.Point(35, 225);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(141, 31);
            this.lblOrderStatus.TabIndex = 20;
            this.lblOrderStatus.Text = "Order Status";
            this.c1ThemeController1.SetTheme(this.lblOrderStatus, "(default)");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label4.Location = new System.Drawing.Point(34, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "Order ID";
            this.c1ThemeController1.SetTheme(this.label4, "(default)");
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblOrderDate.Location = new System.Drawing.Point(34, 145);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(127, 31);
            this.lblOrderDate.TabIndex = 21;
            this.lblOrderDate.Text = "Order Date";
            this.c1ThemeController1.SetTheme(this.lblOrderDate, "(default)");
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtOrderStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "Status", true));
            this.txtOrderStatus.DataType = typeof(Model.OrderStatus);
            this.txtOrderStatus.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtOrderStatus.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtOrderStatus.Location = new System.Drawing.Point(241, 215);
            this.txtOrderStatus.Multiline = true;
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.Padding = new System.Windows.Forms.Padding(4);
            this.txtOrderStatus.Size = new System.Drawing.Size(280, 80);
            this.txtOrderStatus.TabIndex = 12;
            this.txtOrderStatus.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtOrderStatus, "(default)");
            this.txtOrderStatus.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "ID", true));
            this.txtOrderID.DataType = typeof(int);
            this.txtOrderID.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtOrderID.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtOrderID.Location = new System.Drawing.Point(241, 60);
            this.txtOrderID.Multiline = true;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Padding = new System.Windows.Forms.Padding(4);
            this.txtOrderID.Size = new System.Drawing.Size(280, 80);
            this.txtOrderID.TabIndex = 9;
            this.txtOrderID.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtOrderID, "(default)");
            this.txtOrderID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "OrderDate", true));
            this.txtOrderDate.DataType = typeof(System.DateTime);
            this.txtOrderDate.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtOrderDate.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtOrderDate.FormatType = C1.Win.C1Input.FormatTypeEnum.LongDate;
            this.txtOrderDate.Location = new System.Drawing.Point(241, 135);
            this.txtOrderDate.Multiline = true;
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Padding = new System.Windows.Forms.Padding(4);
            this.txtOrderDate.Size = new System.Drawing.Size(280, 80);
            this.txtOrderDate.TabIndex = 11;
            this.txtOrderDate.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtOrderDate, "(default)");
            this.txtOrderDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // grpEmployeeInfo
            // 
            this.grpEmployeeInfo.BackColor = System.Drawing.Color.White;
            this.grpEmployeeInfo.Controls.Add(this.lblDepartment);
            this.grpEmployeeInfo.Controls.Add(this.lblSupervisorName);
            this.grpEmployeeInfo.Controls.Add(this.lblEmpName);
            this.grpEmployeeInfo.Controls.Add(this.txtDepartmentName);
            this.grpEmployeeInfo.Controls.Add(this.txtSupName);
            this.grpEmployeeInfo.Controls.Add(this.txtEmpName);
            this.grpEmployeeInfo.Enabled = false;
            this.grpEmployeeInfo.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.grpEmployeeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.grpEmployeeInfo.Location = new System.Drawing.Point(32, 128);
            this.grpEmployeeInfo.Name = "grpEmployeeInfo";
            this.grpEmployeeInfo.Size = new System.Drawing.Size(743, 316);
            this.grpEmployeeInfo.TabIndex = 2;
            this.grpEmployeeInfo.TabStop = false;
            this.grpEmployeeInfo.Text = "Employee Information";
            this.c1ThemeController1.SetTheme(this.grpEmployeeInfo, "(default)");
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblDepartment.Location = new System.Drawing.Point(43, 239);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(204, 31);
            this.lblDepartment.TabIndex = 18;
            this.lblDepartment.Text = "Department Name";
            this.c1ThemeController1.SetTheme(this.lblDepartment, "(default)");
            // 
            // lblSupervisorName
            // 
            this.lblSupervisorName.AutoSize = true;
            this.lblSupervisorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblSupervisorName.Location = new System.Drawing.Point(43, 163);
            this.lblSupervisorName.Name = "lblSupervisorName";
            this.lblSupervisorName.Size = new System.Drawing.Size(188, 31);
            this.lblSupervisorName.TabIndex = 17;
            this.lblSupervisorName.Text = "Supervisor Name";
            this.c1ThemeController1.SetTheme(this.lblSupervisorName, "(default)");
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblEmpName.Location = new System.Drawing.Point(43, 88);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(212, 31);
            this.lblEmpName.TabIndex = 16;
            this.lblEmpName.Text = "Initiating Employee";
            this.c1ThemeController1.SetTheme(this.lblEmpName, "(default)");
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartmentName.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentUserBindingSource, "DepartmentName", true));
            this.txtDepartmentName.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtDepartmentName.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtDepartmentName.Location = new System.Drawing.Point(278, 224);
            this.txtDepartmentName.Multiline = true;
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Padding = new System.Windows.Forms.Padding(4);
            this.txtDepartmentName.Size = new System.Drawing.Size(280, 80);
            this.txtDepartmentName.TabIndex = 8;
            this.txtDepartmentName.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtDepartmentName, "(default)");
            this.txtDepartmentName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // currentUserBindingSource
            // 
            this.currentUserBindingSource.DataSource = typeof(Model.Entities.User);
            // 
            // txtSupName
            // 
            this.txtSupName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentUserBindingSource, "SupervisorName", true));
            this.txtSupName.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtSupName.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtSupName.Location = new System.Drawing.Point(278, 144);
            this.txtSupName.Multiline = true;
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Padding = new System.Windows.Forms.Padding(4);
            this.txtSupName.Size = new System.Drawing.Size(280, 80);
            this.txtSupName.TabIndex = 4;
            this.txtSupName.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtSupName, "(default)");
            this.txtSupName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtEmpName
            // 
            this.txtEmpName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpName.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "CreatedEmployeeName", true));
            this.txtEmpName.DisabledForeColor = System.Drawing.Color.Gray;
            this.txtEmpName.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.txtEmpName.Location = new System.Drawing.Point(278, 69);
            this.txtEmpName.Multiline = true;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Padding = new System.Windows.Forms.Padding(4);
            this.txtEmpName.Size = new System.Drawing.Size(280, 80);
            this.txtEmpName.TabIndex = 1;
            this.txtEmpName.Tag = null;
            this.c1ThemeController1.SetTheme(this.txtEmpName, "(default)");
            this.txtEmpName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // itemBindingNavigator
            // 
            this.itemBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.itemBindingNavigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.itemBindingNavigator.BindingSource = this.itemBindingSource;
            this.itemBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.itemBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.itemBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.itemBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.bindingNavigatorNoLongerNeeded,
            this.toolStripSeparator1,
            this.bindingNavigatorCloseOrder});
            this.itemBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.itemBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.itemBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.itemBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.itemBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.itemBindingNavigator.Name = "itemBindingNavigator";
            this.itemBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.itemBindingNavigator.Size = new System.Drawing.Size(2448, 33);
            this.itemBindingNavigator.TabIndex = 0;
            this.itemBindingNavigator.Text = "bindingNavigator1";
            this.c1ThemeController1.SetTheme(this.itemBindingNavigator, "(default)");
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorNoLongerNeeded
            // 
            this.bindingNavigatorNoLongerNeeded.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bindingNavigatorNoLongerNeeded.Name = "bindingNavigatorNoLongerNeeded";
            this.bindingNavigatorNoLongerNeeded.Size = new System.Drawing.Size(163, 28);
            this.bindingNavigatorNoLongerNeeded.Text = "No Longer Needed";
            this.bindingNavigatorNoLongerNeeded.Click += new System.EventHandler(this.bindingNavigatorNoLongerNeeded_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorCloseOrder
            // 
            this.bindingNavigatorCloseOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bindingNavigatorCloseOrder.Name = "bindingNavigatorCloseOrder";
            this.bindingNavigatorCloseOrder.Size = new System.Drawing.Size(106, 28);
            this.bindingNavigatorCloseOrder.Text = "Close Order";
            this.bindingNavigatorCloseOrder.Click += new System.EventHandler(this.bindingNavigatorCloseOrder_Click);
            // 
            // c1SuperErrorProvider1
            // 
            this.c1SuperErrorProvider1.ContainerControl = this;
            this.c1SuperErrorProvider1.DataSource = this.itemBindingSource;
            this.c1ThemeController1.SetTheme(this.c1SuperErrorProvider1, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.c1Label16);
            this.groupBox1.Controls.Add(this.c1Label17);
            this.groupBox1.Controls.Add(this.c1Label18);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(172, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 307);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PO Information";
            this.c1ThemeController1.SetTheme(this.groupBox1, "(default)");
            // 
            // c1Label16
            // 
            this.c1Label16.AutoSize = true;
            this.c1Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label16.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1Label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.c1Label16.Location = new System.Drawing.Point(37, 230);
            this.c1Label16.Name = "c1Label16";
            this.c1Label16.Padding = new System.Windows.Forms.Padding(4);
            this.c1Label16.Size = new System.Drawing.Size(124, 39);
            this.c1Label16.TabIndex = 7;
            this.c1Label16.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1Label16, "(default)");
            this.c1Label16.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Custom;
            // 
            // c1Label17
            // 
            this.c1Label17.AutoSize = true;
            this.c1Label17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label17.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1Label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.c1Label17.Location = new System.Drawing.Point(37, 149);
            this.c1Label17.Name = "c1Label17";
            this.c1Label17.Padding = new System.Windows.Forms.Padding(4);
            this.c1Label17.Size = new System.Drawing.Size(124, 39);
            this.c1Label17.TabIndex = 6;
            this.c1Label17.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1Label17, "(default)");
            this.c1Label17.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Custom;
            // 
            // c1Label18
            // 
            this.c1Label18.AutoSize = true;
            this.c1Label18.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label18.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1Label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.c1Label18.Location = new System.Drawing.Point(37, 69);
            this.c1Label18.Name = "c1Label18";
            this.c1Label18.Padding = new System.Windows.Forms.Padding(4);
            this.c1Label18.Size = new System.Drawing.Size(124, 39);
            this.c1Label18.TabIndex = 3;
            this.c1Label18.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1Label18, "(default)");
            this.c1Label18.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Custom;
            // 
            // c1TextBox2
            // 
            this.c1TextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.c1TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "ID", true));
            this.c1TextBox2.DataType = typeof(int);
            this.c1TextBox2.DisabledForeColor = System.Drawing.Color.Gray;
            this.c1TextBox2.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1TextBox2.Location = new System.Drawing.Point(-173, -26);
            this.c1TextBox2.Name = "c1TextBox2";
            this.c1TextBox2.Padding = new System.Windows.Forms.Padding(4);
            this.c1TextBox2.Size = new System.Drawing.Size(226, 44);
            this.c1TextBox2.TabIndex = 13;
            this.c1TextBox2.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1TextBox2, "(default)");
            this.c1TextBox2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox3
            // 
            this.c1TextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.c1TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox3.DataType = typeof(System.DateTime);
            this.c1TextBox3.DisabledForeColor = System.Drawing.Color.Gray;
            this.c1TextBox3.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1TextBox3.Location = new System.Drawing.Point(0, 0);
            this.c1TextBox3.Name = "c1TextBox3";
            this.c1TextBox3.Padding = new System.Windows.Forms.Padding(4);
            this.c1TextBox3.Size = new System.Drawing.Size(100, 44);
            this.c1TextBox3.TabIndex = 0;
            this.c1TextBox3.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1TextBox3, "(default)");
            this.c1TextBox3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox4
            // 
            this.c1TextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.c1TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox4.DisabledForeColor = System.Drawing.Color.Gray;
            this.c1TextBox4.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1TextBox4.Location = new System.Drawing.Point(0, 0);
            this.c1TextBox4.Multiline = true;
            this.c1TextBox4.Name = "c1TextBox4";
            this.c1TextBox4.Padding = new System.Windows.Forms.Padding(4);
            this.c1TextBox4.Size = new System.Drawing.Size(100, 44);
            this.c1TextBox4.TabIndex = 0;
            this.c1TextBox4.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1TextBox4, "(default)");
            this.c1TextBox4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1TextBox4.Validated += new System.EventHandler(this.Item_Validated);
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.c1TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.purchaseOrderBindingSource, "Status", true));
            this.c1TextBox1.DataType = typeof(Model.OrderStatus);
            this.c1TextBox1.DisabledForeColor = System.Drawing.Color.Gray;
            this.c1TextBox1.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.c1TextBox1.Location = new System.Drawing.Point(-173, 129);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Padding = new System.Windows.Forms.Padding(4);
            this.c1TextBox1.Size = new System.Drawing.Size(226, 44);
            this.c1TextBox1.TabIndex = 16;
            this.c1TextBox1.Tag = null;
            this.c1ThemeController1.SetTheme(this.c1TextBox1, "(default)");
            this.c1TextBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // lblItemsForPO
            // 
            this.lblItemsForPO.AutoSize = true;
            this.lblItemsForPO.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsForPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblItemsForPO.Location = new System.Drawing.Point(754, 824);
            this.lblItemsForPO.Name = "lblItemsForPO";
            this.lblItemsForPO.Size = new System.Drawing.Size(625, 38);
            this.lblItemsForPO.TabIndex = 16;
            this.lblItemsForPO.Text = "Items for Purchase Order (clickable to modify)";
            this.c1ThemeController1.SetTheme(this.lblItemsForPO, "(default)");
            // 
            // POMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2492, 1304);
            this.Controls.Add(this.c1DockingTab1);
            this.Name = "POMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Main Form";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.POMainForm_FormClosing);
            this.Load += new System.EventHandler(this.POMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.browsePOTab.ResumeLayout(false);
            this.browsePOTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).EndInit();
            this.tabMaintainPO.ResumeLayout(false);
            this.tabMaintainPO.PerformLayout();
            this.grpProcess.ResumeLayout(false);
            this.grpProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenyReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemStatus)).EndInit();
            this.grpTotals.ResumeLayout(false);
            this.grpTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).EndInit();
            this.grpItemInfo.ResumeLayout(false);
            this.grpItemInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifyReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJusitifcation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            this.grpPOInfo.ResumeLayout(false);
            this.grpPOInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate)).EndInit();
            this.grpEmployeeInfo.ResumeLayout(false);
            this.grpEmployeeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingNavigator)).EndInit();
            this.itemBindingNavigator.ResumeLayout(false);
            this.itemBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SuperErrorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage tabMaintainPO;
        private C1.Win.C1Command.C1DockingTabPage browsePOTab;
        private System.Windows.Forms.BindingSource purchaseOrderBindingSource;
        private C1.Win.C1FlexGrid.C1FlexGrid gridPurchaseOrders;
        private C1.Win.C1FlexGrid.C1FlexGridSearchPanel c1FlexGridSearchPanel1;
        private System.Windows.Forms.BindingNavigator itemBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.GroupBox grpEmployeeInfo;
        private C1.Win.C1Input.C1TextBox txtEmpName;
        private C1.Win.C1SuperTooltip.C1SuperErrorProvider c1SuperErrorProvider1;
        private C1.Win.C1Input.C1TextBox txtDepartmentName;
        private C1.Win.C1Input.C1TextBox txtSupName;
        private System.Windows.Forms.GroupBox grpPOInfo;
        private C1.Win.C1Input.C1TextBox txtOrderStatus;
        private C1.Win.C1Input.C1TextBox txtOrderID;
        private C1.Win.C1Input.C1TextBox txtOrderDate;
        private System.Windows.Forms.GroupBox grpItemInfo;
        private C1.Win.C1Input.C1TextBox txtJusitifcation;
        private C1.Win.C1Input.C1TextBox txtName;
        private C1.Win.C1Input.C1TextBox txtDesc;
        private C1.Win.C1Input.C1TextBox txtPrice;
        private C1.Win.C1Input.C1TextBox txtLocation;
        private C1.Win.C1Input.C1TextBox txtQuantity;
        private C1.Win.C1FlexGrid.C1FlexGrid gridPOItems;
        private System.Windows.Forms.GroupBox grpTotals;
        private C1.Win.C1Input.C1TextBox txtPOTotal;
        private C1.Win.C1Input.C1TextBox txtPOSubtotal;
        private C1.Win.C1Input.C1TextBox txtPOTax;
        private System.Windows.Forms.GroupBox grpProcess;
        private C1.Win.C1Input.C1ComboBox cboItemStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Label c1Label16;
        private C1.Win.C1Input.C1Label c1Label17;
        private C1.Win.C1Input.C1Label c1Label18;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Input.C1TextBox c1TextBox2;
        private C1.Win.C1Input.C1TextBox c1TextBox3;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblSupervisorName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblJustification;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorNoLongerNeeded;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCloseOrder;
        private C1.Win.C1Input.C1TextBox txtDenyReason;
        private System.Windows.Forms.Label lblDenyReason;
        private C1.Win.C1Input.C1TextBox c1TextBox4;
        private C1.Win.C1Input.C1TextBox txtModifyReason;
        private System.Windows.Forms.Label lblModifyReason;
        private System.Windows.Forms.Label lblBrowseType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.Label lblPoAction;
        private System.Windows.Forms.BindingSource currentUserBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblItemsForPO;
    }
}
