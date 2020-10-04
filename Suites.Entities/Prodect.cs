using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Entities
{
    public partial  class Prodect : BaseEntity 
    {
        public string ImageURL { get; set; }
        public int prise { get; set; }
        public int categoryID { get; set; }
        public Category Category { get; set; }

    }
}
