using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Article:IEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content_summary { get; set; }
        public string content_main { get; set; }
        public DateTime publish_date { get; set; }
        public string picture { get; set; }
        public int category_id { get; set; }
        public int viewCount { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

