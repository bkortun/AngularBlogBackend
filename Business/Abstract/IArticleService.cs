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
        IDataResult<List<ArticleDetailDto>> GetAllAdmin();
        IDataResult<Tuple<ArticlePg>> GetAllWithPagination(int page, int pageSize);
        IDataResult<Article> GetById(int articleId);

        IDataResult<ArticleDetailDto> GetByArticleDetails(int articleId);
        IResult Insert(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IDataResult<List<Article>> GetByCategory(int categoryId);
        IDataResult<Tuple<ArticlePg>> GetByCategoryWithPagination(int categoryId, int page, int pageSize);
        IDataResult<Tuple<ArticlePg>> GetBySearch(string searchText, int page, int pageSize);
        IDataResult<List<Article>> GetByMostView();
        IDataResult<IQueryable> GetArticlesArchive();
        IDataResult<Tuple<ArticlePg>> GetArticleArchiveList(int month, int year, int page, int pageSize);

        IDataResult<int> ArticleCountUp(int id);


        //IDataResult<List<Article>> GetArticlesByMostView();
        //IDataResult<List<Article>> GetArchive();
        //IDataResult<List<Article>> GetArchiveList();

        //Tuple<IEnumerable<ArticleDetailDto>, int> ArticlePagination(IQueryable<Article> query, int page, int pageSize);
    }
}
