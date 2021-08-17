using AutoMapper;
using cmkts.blog.business.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmkts.blog.wepapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PostVM>> GetAllBlogs()
        {
            return _mapper.Map<List<PostVM>>(await _blogService.GetAllAsync());
        }
        [HttpGet("name")]
        public async Task<Post> GetBlogByName(string name)
        {
            return await _blogService.GetPostByName(name);
        }

        [HttpGet("category")]
        public async Task<List<PostVM>> GetPostsByCategory(string category)
        {
            return _mapper.Map<List<PostVM>>(await _blogService.GetPostByCategory(category));
        }
    }
}
