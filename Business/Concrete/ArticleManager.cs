using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal, ICategoryService categoryService)
        {
            _articleDal = articleDal;
        }

        public IDataResult<int> ArticleCountUp(int id)
        {
            return new SuccessDataResult<int>(_articleDal.ArticleCountUp(id));
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult();
        }

        public IDataResult<List<Article>> GetAll()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll().ToList());
        }

        public IDataResult<Tuple<ArticlePg>> GetAll(int page, int pageSize)
        {
            return new SuccessDataResult<Tuple<ArticlePg>>(_articleDal.GetAll(page,pageSize));
        }

        public IDataResult<Tuple<ArticlePg>> GetArticleArchiveList(int month, int year, int page, int pageSize)
        {
            return new SuccessDataResult<Tuple<ArticlePg>>(_articleDal.GetArticleArchiveList(month,year,page,pageSize));
        }

        public IDataResult<IQueryable> GetArticlesArchive()
        {
            return new SuccessDataResult<IQueryable>(_articleDal.GetArticlesArchive());
        }

        public IDataResult<ArticleDetailDto> GetByArticleDetails(int articleId)
        {
            return new SuccessDataResult<ArticleDetailDto>(_articleDal.GetDetails(articleId));
        }

        public IDataResult<List<Article>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(a => a.CategoryId == categoryId).ToList());
        }
        public IDataResult<Tuple<ArticlePg>> GetByCategory(int categoryId,int page,int pageSize)
        {
            return new SuccessDataResult<Tuple<ArticlePg>>(_articleDal.GetAllByCategory(categoryId,page,pageSize));
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(a => a.Id == articleId));
        }

        public IDataResult<List<Article>> GetByMostView()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll().OrderByDescending(a=>a.ViewCount).Take(5).ToList());
        }

        public IDataResult<Tuple<ArticlePg>> GetBySearch(string searchText, int page, int pageSize)
        {
            return new SuccessDataResult<Tuple<ArticlePg>>(_articleDal.GetAllBySerarch(searchText,page,pageSize));
        }

        public IResult Insert(Article article)
        {
            _articleDal.Insert(article);
            return new SuccessResult();
        }

        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult();
        }
        

     
    }
}
