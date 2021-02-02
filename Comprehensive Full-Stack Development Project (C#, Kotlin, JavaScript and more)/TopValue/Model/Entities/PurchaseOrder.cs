using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrder : Base
    {
        #region Calculated Properties
        private OrderStatus status;
        public OrderStatus Status
        {
            get
            {
                //if (status != OrderStatus.Pending)
                //{
                //    return status;
                //}


                if (this.Items.Count > 0)
                {
                    //if (status == OrderStatus.Pending) status = OrderStatus.Pending;
                    //if (status == OrderStatus.Closed) return status;

                    ////Check if all items are in pending - Assign pending status to PO
                    //if (this.Items.Where(i => i.Status == ItemStatus.Pending).Count() == this.Items.Count) status = OrderStatus.Pending;
                    //else if (this.Items.Where(i => i.Status == ItemStatus.Pending).Count() < this.Items.Count && this.Items.Where(i => i.Status == ItemStatus.Pending).Count() > 0) status = OrderStatus.UnderReview;
                    //else status = OrderStatus.Pending;
                    
                    

                    if(status != OrderStatus.Closed && this.Items.Exists(i=> i.Status != ItemStatus.Pending))
                    {
                        status = OrderStatus.UnderReview;
                    }
                    else if(status != OrderStatus.Closed)
                    {
                        status = OrderStatus.Pending;
                    }
                    //if (this.Items.Where(i => i.NoLongerNeeded).Count() == this.Items.Count())
                    //{
                    //    status = OrderStatus.Closed;
                    //}
                    return status;
                }
                else if (status == 0)
                {
                    status = OrderStatus.Pending;
                    return status;
                }
                else
                {
                    return status;
                }


            }
            set { status = value; }
        }

        private decimal subtotal;
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Subtotal
        {
            get
            {
                //subtotal = 0;
                if (Items.Count > 0)
                {
                    subtotal = 0;
                    this.Items.ForEach(i => subtotal += i.Subtotal);
                }
                return subtotal;
            }
            set { subtotal = value; }
        }
        private decimal taxes;
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Taxes
        {
            get => taxes = this.Subtotal * .15m;
            set { taxes = value; }
        }

        private decimal total;
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Total
        {
            get
            {
                return total = Subtotal + Taxes;
            }
            set { total = value; }
        }
        #endregion


        #region Basic Properties
        public int ID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;
        
        [Browsable(false)]
        public byte[] TimeStamp { get; set; }
        
        [Browsable(false)]
        public List<Item> Items { get; set; } = new List<Item>();
        
        public PurchaseOrder() { }

        public Employee CreatedEmployee { get; set; } = new Employee();
        #endregion

        public void AddItem(Item item)
        {
            //BUsiness Rule for duplication
            if (Items.Where(y => y.Name == item.Name).Count() > 0)
            {
                foreach (Item x in Items)
                {
                    if (x.Name == item.Name)
                    {

                        x.Quantity += item.Quantity;
                    }
                }
            }
            else
            {
                Items.Add(item);
            }
        }

        //Properties for display only

        [DisplayName("CreatedEmployee")]
        public string CreatedEmployeeName => CreatedEmployee?.FullName;
        [DisplayName("CreatedEmployeeSupervisorName")]
        public string CreatedEmpSupervisorName => CreatedEmployee?.Supervisor?.FullName;
        [DisplayName("CreatedEmplyeeDepartment")]
        public string CreatedEmployeeDepartment => CreatedEmployee?.Departments?.Name;
    }
}
