using cmkts.blog.business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;

namespace cmkts.blog.wepapi.Filters
{
    public class CheckAuthorizeAttribute : ActionFilterAttribute,IAsyncAuthorizationFilter
    {
   
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var _userRepository = context.HttpContext.RequestServices.GetService<IUserRoleRepository>();
            var _actionRepository = context.HttpContext.RequestServices.GetService<IActionRepository>();
            var _actionRoleRepository = context.HttpContext.RequestServices.GetService<IActionRoleRepository>();
            string controller = context.RouteData.Values["controller"] as string;
            string action = context.RouteData.Values["action"] as string;
            string authorization = context.HttpContext.Request.Headers["Authorization"];
            var token = authorization.Split(" ").Last();
            var nameidentifier = ValidateToken(token);
            if (nameidentifier == null)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var roles = _userRepository.GetRolesGetByEmail(nameidentifier);
                var actions = _actionRepository.GetContollerActionGetByController(controller);
                if(roles!=null && actions != null)
                {
                    if (!_actionRoleRepository.CheckActionRole(roles, actions))
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                }
                
            }
        }
        
        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("cmktscmktscmkts;;;123852");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var nameidentifier = jwtToken.Claims.First(x => x.Type == "nameidentifier").Value;

                // return user id from JWT token if validation successful
                return nameidentifier;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        
    }
}
