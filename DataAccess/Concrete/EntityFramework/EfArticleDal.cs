using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    Id = x.Id,
                    Title = x.Title,
                    ContentSummary = x.ContentSummary,
                    ContentMain = x.ContentMain,
                    PublishDate = x.PublishDate,
                    Picture = x.Picture,
                    ViewCount = x.ViewCount,
                    CommentCount = x.Comments.Count(),
                    Category=new Category { Id=x.Category.Id,Name=x.Category.Name}
                });
                var result = new ArticlePg
                {
                    Articles = articles,
                    TotalCount = totalCount
                };
                return new Tuple<ArticlePg>(result);
            }
        }

        public ArticleDetailDto GetDetails(int id)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                var article = context.Articles.Include(x => x.Category).Include(y => y.Comments).FirstOrDefault(z => z.Id == id);
                ArticleDetailDto articleResponse = new ArticleDetailDto()
                {
                    Id = article.Id,
                    Title = article.Title,
                    ContentSummary = article.ContentSummary,
                    ContentMain = article.ContentMain,
                    PublishDate = article.PublishDate,
                    Picture = article.Picture,
                    ViewCount = article.ViewCount,
                    CommentCount = article.Comments.Count(),
                    Category = new Category { Id = article.Category.Id, Name = article.Category.Name }
                };
                return articleResponse;
            }
        }

        public Tuple<ArticlePg> GetAll(int page, int pageSize)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.Articles.Include(x => x.Category).Include(y => y.Comments).OrderByDescending(z => z.PublishDate);
                return ArticlePagination(query, page, pageSize);
            }
           
        }

        public Tuple<ArticlePg> GetAllByCategory(int id, int page, int pageSize)
        {
            using (var context=new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query=context.Articles.Include(x => x.Category).Include(y => y.Comments).Where(a=>a.CategoryId == id).OrderByDescending(z => z.PublishDate);
                return ArticlePagination(query,page,pageSize);
            }
        }

        public Tuple<ArticlePg> GetAllBySerarch(string searchText, int page, int pageSize)
        {
            using (var context = new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.Articles.Include(x => x.Category).Include(y => y.Comments).Where(a => a.Title.Contains(searchText)).OrderByDescending(z => z.PublishDate);
                return ArticlePagination(query, page, pageSize);
            }
        }

        public Tuple<ArticlePg> GetArticleArchiveList(int month, int year, int page, int pageSize)
        {
            using (var context=new UdemyAngularBlogDBContext())
            {
                IQueryable<Article> query;
                query = context.Articles.Include(x => x.Category).Include(y => y.Comments).Where(a => a.PublishDate.Month==month&&a.PublishDate.Year==year).OrderByDescending(z=>z.PublishDate);
                return ArticlePagination(query, page, pageSize);
            }
        }

        public  IQueryable<Archive>  GetArticlesArchive()
        {
            using (var context= new UdemyAngularBlogDBContext())
            {
                IQueryable<Archive> query;
                query = context.Articles.GroupBy(x=> new { x.PublishDate.Month, x.PublishDate.Year }).Select(x => new Archive
                {
                     Month = x.Key.Month,
                     Year = x.Key.Year,
                    Count = x.Count(),
                    MonthName = new DateTime(x.Key.Year, x.Key.Month, 1).ToString("MMMM")
                });
           
                return query;
                
            }
        }

        public int ArticleCountUp(int id)
        {
            using (var context= new UdemyAngularBlogDBContext())
            {
                var article = context.Articles.Find(id);
                article.ViewCount = article.ViewCount + 1;
                context.SaveChanges();
                return article.ViewCount;

            }
        }

        public List<ArticleDetailDto> GetAllAdmin()
        {
            using (var context=new UdemyAngularBlogDBContext())
            {
                var result = from a in context.Articles
                             join c in context.Categories
                             on a.CategoryId equals c.Id
                             select new ArticleDetailDto
                             {
                                 Id = a.Id,
                                 Title = a.Title,
                                 ContentSummary = a.ContentSummary,
                                 ContentMain = a.ContentMain,
                                 PublishDate = a.PublishDate,
                                 CategoryId = a.CategoryId,
                                 ViewCount = a.ViewCount,
                                 CommentCount = a.Comments.Count(),
                                 Category = new Category { Id=c.Id,Name=c.Name}
                             };
                return result.ToList() ;
            }
        }
    }
}
