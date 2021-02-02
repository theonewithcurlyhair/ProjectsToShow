using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EmployeeVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string JobName { get; set; }
        public string DepartmentsName { get; set; }
        public string OfficeLocation { get; set; }
    }
}