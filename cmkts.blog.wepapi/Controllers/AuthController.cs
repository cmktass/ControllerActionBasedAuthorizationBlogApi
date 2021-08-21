using cmkts.blog.business.Interface;
using cmkts.blog.business.JwtTool;
using cmkts.blog.viewmodel.ViewModels;
using cmkts.blog.wepapi.Filters;
using Microsoft.AspNetCore.Authorization;
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
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IGenerateJwtToken _generateJwt;
        public AuthController(IUserService userService, IGenerateJwtToken generateJwt)
        {
            _userService = userService;
            _generateJwt = generateJwt;
        }

        [HttpPost]
        [ModelValidation]
        public async Task<bool> Register(UserVM userVM)
        {
            return await _userService.Register(userVM);
        }
        [HttpPost]
        [ModelValidation]
        public async Task<GenericResponse<string>> Login(UserLoginVM userVM)
        {
            var response = await _userService.Login(userVM);
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                response.Data = _generateJwt.GenerateToken(userVM);
                return response;
            }
            else
            {
                return response;
            }
        }

        [CheckAuthorizeAttribute]
        [HttpGet]
        public void Logout()
        {

        }
    }
}
