using cmkts.blog.business.Concrete;
using cmkts.blog.business.Interface;
using cmkts.blog.business.JwtTool;
using cmkts.blog.dataaccess.Concrete.EntityFramework.Repository;
using cmkts.blog.dataaccess.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace cmkts.blog.business.MicrosoftIoC
{
    public static class MicIoC
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddScoped<IUserRoleRepository, UserRoleRepository>();
            service.AddScoped<IUserActivityRepository, UserActivityRepository>();
            service.AddScoped<IActionRepository, ActionRepository>();
            service.AddScoped<IActionRoleRepository, ActionRoleRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();



            service.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ICategoryService, CategoryService>();



            service.AddScoped<IGenerateJwtToken, GenerateJwtToken>();
        }
    }
}
