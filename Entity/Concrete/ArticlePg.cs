using Core.Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ArticlePg:IEntity
    {
        public IEnumerable<ArticleDetailDto> Articles { get; set; }
        public int TotalCount { get; set; }
    }
}
