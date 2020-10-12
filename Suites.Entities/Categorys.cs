using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Entities
{
    [MetadataType(typeof(metadataCategor))]
    public partial class Category
    {

    }
    public class metadataCategor
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50), MinLength(5)]
        [Display(Name = "Name of Categor")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Image of Categor")]
        public string ImageURL { get; set; }
        public bool ISFeatcher { get; set; }
        public List<Prodect> prodects { get; set; }
    }

 }
