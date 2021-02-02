using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Departments : Base
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime InvocDate { get; set; }

        public byte[] TimeStamp { get; set; }
    }
}
