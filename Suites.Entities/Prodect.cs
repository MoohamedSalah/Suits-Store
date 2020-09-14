using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Entities
{
    public class Prodect : BaseEntity 
    {
        public int prise { get; set; }
        public Category Category { get; set; }

    }
}
