using AutoMapper;
using cmkts.blog.business.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using cmkts.blog.viewmodel.ViewModels.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmkts.blog.webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IControllerService _controllerService;
        private IControllerActionService _controllerActionService;
        private readonly IMapper _mapper;
        public AdminController(IMapper mapper, IControllerService controllerService, IControllerActionService controllerActionService)
        {
            _controllerService = controllerService;
            _controllerActionService = controllerActionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<cmkts.blog.entities.Entities.Controller>> GetAllController()
        {
            return await _controllerService.GetAllAsync();
        }
        [HttpGet("name")]
        public async Task<GenericResponse<cmkts.blog.entities.Entities.Controller>> GetControllerByName(string name)
        {
            return await _controllerService.FindByFilter(i=>i.ControllerName==name);
        }
        [HttpPost]
        public async Task<GenericResponse<cmkts.blog.entities.Entities.Controller>> AddController(ControllerVM controllerVM)
        {
            return await _controllerService.AddAsync(_mapper.Map<cmkts.blog.entities.Entities.Controller>(controllerVM));
        }
        [HttpPut]
        public async Task<GenericResponse<cmkts.blog.entities.Entities.Controller>> UpdateController(ControllerVM controllerVM)
        {
            return await _controllerService.UpdateAsync(_mapper.Map<cmkts.blog.entities.Entities.Controller>(controllerVM));
        }
        [HttpDelete("id")]
        public async Task<GenericResponse<int>> DeleteController(int id)
        {
            return await _controllerService.DeleteAsync(id);
        }
        [HttpGet("id")]
        public async Task<GenericResponse<cmkts.blog.entities.Entities.Controller>> GetControllerWithActions(int id)
        {
            return await _controllerService.GetControllerWithActions(id);
        }
        [HttpGet("id")]
        public async Task<GenericResponse<ControllerAction>> GetAction(int id)
        {
            return await _controllerActionService.FindByFilter(i => i.Id == id);
        }
        [HttpPost]
        public async Task<GenericResponse<ControllerAction>> AddAction(ControllerAction controllerAction)
        {
            return await _controllerActionService.AddAsync(controllerAction);
        }
        [HttpPut]
        public async Task<GenericResponse<ControllerAction>> UpdateAction(ControllerAction controllerAction)
        {
            return await _controllerActionService.UpdateAsync(controllerAction);
        }
        [HttpDelete("id")]
        public async Task<GenericResponse<int>> DeleteAction(int id)
        {
            return await _controllerActionService.DeleteAsync(id);
        }
    }
}
