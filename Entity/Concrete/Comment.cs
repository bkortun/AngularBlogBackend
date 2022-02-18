using Core.Entities;
using System;
using System.Collections.Generic;
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

        public virtual Article Article { get; set; }
    }
}
