using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.UseCases;
using Pokemon.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infra.IoC.DependencyInjection
{
    public static class DIDomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IPokeApiService, PokeApiService>();

            services.AddScoped<IPokemonMasterService, PokemonMasterService>();

            return services;
        }
    }
}



