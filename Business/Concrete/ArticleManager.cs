using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        private ICategoryService _categoryService;
        public ArticleManager(IArticleDal articleDal, ICategoryService categoryService)
        {
            _articleDal = articleDal;
            _categoryService = categoryService;
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

        public IDataResult<List<Article>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(a => a.category_id == categoryId).ToList());
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(a => a.id == articleId));
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
