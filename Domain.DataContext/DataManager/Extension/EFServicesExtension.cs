using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Extension
{
    public static class EFServicesExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:sqlConnection"];
            services.AddDbContext<DataContext>(o => o.UseMySql(connectionString));
        }
    }
}
