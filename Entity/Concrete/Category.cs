﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
