﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Entities
{
    public  class Category : BaseEntity
    {
        public List<Prodect> prodects { get; set; }
             
    }
}
