using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Employee : Base
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("Employee")]
        public string FullName => MName == "" ? $"{FName}, {LName}" : $"{FName}, {MName}, {LName}";
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string SIN { get; set; }
        public DateTime SeniorityDate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public Job Job { get; set; }
        public DateTime JobStartDate { get; set; }
        public string Email { get; set; }
        public int SupervisorID { get; set; }
        public Departments Departments { get; set; } //= new Departments();
        public string Country { get; set; }
        public string Province { get; set; }
        public string OfficeLocation { get; set; }
        public bool IsSupervisor { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Address => this.StreetAddress + " , " + this.City + " , " + this.Province + " " + this.Country + "," + this.PostalCode;
        public Employee() { }

        public Employee Supervisor { get; set; } //= new Employee();

        [DisplayName("SupervisorFullName")]
        public string SupervisorName => Supervisor?.FullName ?? "";

        [DisplayName("DepartmentName")]
        public string DepartmentName => Departments.Name;

        public override string ToString() => $"Active User Name : {FullName} \t| Employee ID : #{ID} \t| Department : {DepartmentName} \t| Department Supervisor : {SupervisorName}";
    }
}
