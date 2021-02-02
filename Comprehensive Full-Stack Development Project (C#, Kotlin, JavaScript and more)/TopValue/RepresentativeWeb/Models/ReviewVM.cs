using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Models
{
    public class ReviewVM
    {
        public Review Review { get; set; }

        public List<SelectListItem> supervisedEmployeeList { get; set; }

    }
}