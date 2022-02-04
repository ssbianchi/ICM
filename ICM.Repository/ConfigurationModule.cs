using ICM.Domain.Barco.Repository;
using ICM.Domain.Conta.Repository;
using ICM.Domain.Funcionario.Repository;
using ICM.Domain.Responsavel.Repository;
using ICM.Domain.Titulo.Repository;
using ICM.Repository.Context;
using ICM.Repository.Mockup;
using ICM.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ICM.Repository
{
    public static class ConfigurationModule
    {
        public static void RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ICMContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped<ISocioRepository, SocioRepository>();
            services.AddScoped<IInfoBasicaRepository, InfoBasicaRepository>();
            services.AddScoped<IHabilitacaoNauticaRepository, HabilitacaoNauticaRepository>();
            services.AddScoped<IEmbarcacaoRepository, EmbarcacaoRepository>();
            services.AddScoped<ITituloSocioRepository, TituloSocioRepository>();
            services.AddScoped<IDependenteRepository, DependenteRepository>();
            services.AddScoped<ITripulanteRepository, TripulanteRepository>();

            //services.AddScoped<ISocioRepository, MockupSocioRepository>();
        }
    }
}
