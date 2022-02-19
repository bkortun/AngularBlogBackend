using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<List<Article>> GetAll();
        IDataResult<Tuple<ArticlePg>> GetAll(int page, int pageSize);
        IDataResult<Article> GetById(int articleId);
        IResult Insert(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IDataResult<List<Article>> GetByCategory(int categoryId);
        //IDataResult<List<Article>> GetArticlesByMostView();
        //IDataResult<List<Article>> GetArchive();
        //IDataResult<List<Article>> GetArchiveList();

        //Tuple<IEnumerable<ArticleDetailDto>, int> ArticlePagination(IQueryable<Article> query, int page, int pageSize);
    }
}
