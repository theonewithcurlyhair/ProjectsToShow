using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Job
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
