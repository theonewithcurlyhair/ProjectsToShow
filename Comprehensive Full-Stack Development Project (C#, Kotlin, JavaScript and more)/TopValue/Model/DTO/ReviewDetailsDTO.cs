using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ReviewDetailsDTO
    {
        public Review review { get; set; }
        public string SupervisorName { get; set; }
    }
}
