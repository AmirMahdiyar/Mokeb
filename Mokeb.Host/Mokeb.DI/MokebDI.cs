using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mokeb.Infrastructure.Context;

namespace Mokeb.DI
{
    public static class MokebDI
    {
        public static IServiceCollection MokebDependencyInjection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MokebDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return service;
        }
    }
}
