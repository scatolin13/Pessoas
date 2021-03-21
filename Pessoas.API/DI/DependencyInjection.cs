using Microsoft.Extensions.DependencyInjection;
using Pessoas.Port.Interfaces;
using Pessoas.Port.Ports;
using Pessoas.Repository.Interfaces;
using Pessoas.Repository.Repositories;
using Pessoas.Service.Interfaces;
using Pessoas.Service.Services;

namespace Pessoas.API.DI
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaPort, PessoaPort>();
            services.AddTransient<IPessoaRepository>(x => new PessoaRepository(connectionString));
        }
    }
}
