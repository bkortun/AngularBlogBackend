﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

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
        [HttpGet("GetArticlesAdmin")]
        public IActionResult GetArticlesAdmin()
        {
            var result = _articleService.GetAllAdmin();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetArticles(int page,int pageSize)
        {
            var result = _articleService.GetAllWithPagination(page, pageSize);
            if (result.Success)
            {
                return Ok(result.Data.Item1);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var result = _articleService.GetByArticleDetails(id);
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
            var result=_articleService.GetByCategoryWithPagination(id,page,pageSize);
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
        [HttpGet]
        [Route("ArticleViewCountUp/{id}")]
        public IActionResult ArticleViewCountUp(int id)
        {
            var result=_articleService.ArticleCountUp(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Route("SaveArticlePicture")]
        public async Task<IActionResult> SaveArticlePicture(IFormFile picture)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/articlePictures", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            var result = new
            {
                path = "https://" + Request.Host + "/articlePictures/" + fileName

            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(Article article)
        {
            if (article.Category != null)
            {
                article.CategoryId = article.Category.Id;
            }
            article.Category = null;
            article.ViewCount = 0;
            article.PublishDate = DateTime.Now;
            var result= _articleService.Insert(article);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

    }
}
