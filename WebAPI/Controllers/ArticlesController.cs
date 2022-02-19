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
    }
}
