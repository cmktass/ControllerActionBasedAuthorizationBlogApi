using cmkts.blog.business.Infos.JwtInfo;
using cmkts.blog.viewmodel.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cmkts.blog.business.JwtTool
{
    public class GenerateJwtToken: IGenerateJwtToken
    {
        public string GenerateToken(UserLoginVM userVM)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenInfo.Issuer,
                audience: JwtTokenInfo.Audience, 
                claims: SetClaims(userVM), 
                notBefore: DateTime.Now, 
                expires: DateTime.Now.AddMinutes(JwtTokenInfo.Expires),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
             return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> SetClaims(UserLoginVM userVM)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("nameidentifier", userVM.Email));
            return claims;
        }
    }
}
