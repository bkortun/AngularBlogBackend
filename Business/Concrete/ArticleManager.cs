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
