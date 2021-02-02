using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Models
{
    public class EmpSearchVM
    {
        public User User { get; set; }

        public List<SelectListItem> searchList { get; set; }
        public List<SelectListItem> foundEmployee { get; set; }
    }
}