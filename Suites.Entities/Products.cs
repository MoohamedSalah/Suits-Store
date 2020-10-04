using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Suites.Entities
{
    [MetadataType(typeof(metadataProduct))]
    public partial class Prodect
    {

    }

    public class metadataProduct
    {

        public int ID { get; set; }

        [Required]
        [MaxLength(50),MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public int prise { get; set; }
        public int categoryID { get; set; }

    }
}
