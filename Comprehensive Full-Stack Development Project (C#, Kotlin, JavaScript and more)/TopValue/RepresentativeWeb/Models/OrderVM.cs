using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIgSystemSolutions_Web.Models
{
    public class OrderVM
    {
        public PurchaseOrder Order { get; set; }
        public Item Item { get; set; }
    }
}