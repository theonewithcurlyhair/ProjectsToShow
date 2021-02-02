using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Review : Base
    {
        public int ID { get; set; }
        public PerfomanceRating PerfomanceRating { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }

        public int EmployeeId { get; set; }

        public int ReviewQuater { get; set; }
    }
}
