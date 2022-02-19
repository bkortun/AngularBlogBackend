using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, UdemyAngularBlogDBContext>, IArticleDal
    {
        public Tuple<ArticlePg> ArticlePagination(IQueryable<Article> query,int page, int pageSize)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                
                int totalCount = query.Count();
                var articles = query.Skip(pageSize * (page - 1)).Take(5).ToList().Select(x => new ArticleDetailDto
                {
                    id = x.id,
                    title = x.title,
                    content_summary = x.content_summary,
                    content_main = x.content_main,
                    publish_date = x.publish_date,
                    picture = x.picture,
                    viewCount = totalCount,
                    commentCount = x.Comments.Count(),
                    category=new Category { id=x.Category.id,name=x.Category.name}
                });
                var result = new ArticlePg
                {
                    Articles = articles,
                    TotalCount = totalCount
                };
                return new Tuple<ArticlePg>(result);
            }
        }

        public Tuple<ArticlePg> GetAll(int page, int pageSize)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.article.Include(x => x.Category).Include(y => y.Comments).OrderByDescending(z => z.publish_date);
                return ArticlePagination(query, page, pageSize);
            }
           
        }
    }
}
