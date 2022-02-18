using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<Article> GetById(int articleId);
        IResult Insert(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);
        IDataResult<List<Article>> GetByCategory(int categoryId);
        //IDataResult<List<Article>> GetArticlesByMostView();
        //IDataResult<List<Article>> GetArchive();
        //IDataResult<List<Article>> GetArchiveList();

    }
}
