using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int id { get; set; }
        public int article_id { get; set; }
        public string name { get; set; }
        public string content_main { get; set; }
        public DateTime publish_date { get; set; }

        [ForeignKey("article_id")]
        public virtual Article Article { get; set; }
    }
}
