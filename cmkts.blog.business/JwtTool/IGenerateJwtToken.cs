using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmkts.blog.business.JwtTool
{
    public interface IGenerateJwtToken
    {
        string GenerateToken(UserVM userVM);
    }
}
