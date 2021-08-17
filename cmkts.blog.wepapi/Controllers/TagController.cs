using AutoMapper;
using cmkts.blog.business.Interface;
using cmkts.blog.viewmodel.ViewModels.Tag;
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
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<TagVM>> GetAllTag()
        {
            return _mapper.Map<List<TagVM>>(await _tagService.GetAllAsync());
        }
    }
}
