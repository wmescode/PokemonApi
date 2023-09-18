using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Domain.Helpers;
using Pokemon.Domain.Repositories;
using Pokemon.Infra.Data.Context;
using Pokemon.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infra.IoC.DependencyInjection
{
    public static class DIInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {            
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPokemonMasterRepository, PokemonMasterRepository>();            
            
            return services;
        }
    }
}
