using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ArticleDetailDto:IDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content_summary { get; set; }
        public string content_main { get; set; }
        public DateTime publish_date { get; set; }
        public string picture { get; set; }
        public int category_id { get; set; }
        public int viewCount { get; set; }
        public int commentCount { get; set; }

        public Category category { get; set; }
    }
}
