using cmkts.blog.business.Concrete;
using cmkts.blog.business.Interface;
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
            service.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IUserService, UserService>();
        }
    }
}
