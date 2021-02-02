using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : Employee
    {
        public Status Status { get; set; }
        public DateTime StatusDate { get; set; }
        public string Password { get; set; }
        public byte[] TimeStamp { get; set; }
        public User() : base(){
            Departments = new Departments();
            Supervisor = new Employee();
        }
    }
}
