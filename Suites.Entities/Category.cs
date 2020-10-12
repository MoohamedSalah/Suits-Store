using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Entities
{
    public partial class Category : BaseEntity
    {
        public string ImageURL { get; set; }
        public bool ISFeatcher { get; set; }
        public List<Prodect> prodects { get; set; }
             
    }
}
