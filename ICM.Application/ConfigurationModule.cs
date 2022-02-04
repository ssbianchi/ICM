using ICM.Application.Barco.Service;
using ICM.Application.Conta.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ICM.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            service.AddScoped<ISocioService, SocioService>();
            service.AddScoped<IEmbarcacaoService, EmbarcacaoService>();
        }
    }
}
