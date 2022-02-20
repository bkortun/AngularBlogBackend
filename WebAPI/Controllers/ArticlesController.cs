using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService= articleService;
        }
        [HttpGet]
        public IActionResult GetArticles()
        {
            var result = _articleService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetArticles(int page,int pageSize)
        {
            var result = _articleService.GetAll(page, pageSize);
            if (result.Success)
            {
                return Ok(result.Data.Item1);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var result = _articleService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetArticleWithCategory/{id}/{page}/{pageSize}")]
        public IActionResult GetArticleWithCategory(int id,int page,int pageSize)
        {
            var result=_articleService.GetByCategory(id,page,pageSize);
            if (result.Success)
            {
                return Ok(result.Data.Item1);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("SearchArticles/{searchText}/{page}/{pageSize}")]
        public IActionResult SearchArticles(string searchText,int page,int pageSize)
        {
            var result=_articleService.GetBySearch(searchText,page,pageSize);
            if (result.Success)
            {
                return Ok(result.Data.Item1);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetArticlesByMostView")]
        public IActionResult GetArticlesByMostView()
        {
            var result = _articleService.GetByMostView();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetArticlesArchive")]
        public IActionResult GetArticlesArchive()
        {
            var result = _articleService.GetArticlesArchive();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("GetArticleArchiveList/{year}/{month}/{page}/{pageSize}")]
        public IActionResult GetArticleArchiveList(int month, int year, int page, int pageSize)
        {
            var result = _articleService.GetArticleArchiveList(month, year, page, pageSize);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
