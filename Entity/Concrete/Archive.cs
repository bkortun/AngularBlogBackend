using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Archive:IEntity
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public string MonthName { get; set; }
    }
}
