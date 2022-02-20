using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
        Tuple<ArticlePg> ArticlePagination(IQueryable<Article> query,int page, int pageSize);
        Tuple<ArticlePg> GetAll(int page, int pageSize);
        Tuple<ArticlePg> GetAllByCategory(int id,int page, int pageSize);
        Tuple<ArticlePg> GetAllBySerarch(string searchText,int page, int pageSize);
        Tuple<ArticlePg> GetArticleArchiveList(int month,int year, int page, int pageSize);
        IQueryable GetArticlesArchive();
    }
}
