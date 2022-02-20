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

        public Tuple<ArticlePg> GetAllByCategory(int id, int page, int pageSize)
        {
            using (var context=new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query=context.article.Include(x => x.Category).Include(y => y.Comments).Where(a=>a.category_id == id).OrderByDescending(z => z.publish_date);
                return ArticlePagination(query,page,pageSize);
            }
        }

        public Tuple<ArticlePg> GetAllBySerarch(string searchText, int page, int pageSize)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.article.Include(x => x.Category).Include(y => y.Comments).Where(a => a.title.Contains(searchText)).OrderByDescending(z => z.publish_date);
                return ArticlePagination(query, page, pageSize);
            }
        }

        public Tuple<ArticlePg> GetArticleArchiveList(int month, int year, int page, int pageSize)
        {
            using (var context=new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.article.Include(x => x.Category).Include(y => y.Comments).Where(a => a.publish_date.Month==month&&a.publish_date.Year==year).OrderByDescending(z => z.publish_date);
                return ArticlePagination(query, page, pageSize);
            }
        }

        public IQueryable GetArticlesArchive()
        {
            using (var context= new UdemyAngularBlogDBContext())
            {
                 var query = context.article.GroupBy(x => new {  x.publish_date.Month, x.publish_date.Year }).Select(x => new
                {
                     month = x.Key.Month,
                     year = x.Key.Year,
                    count = x.Count(),
                    monthName = new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM")
                });
                context.Dispose();
                return query;
                
            }
        }
    }
}
