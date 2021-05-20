using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pessoas.API.DI;
using Pessoas.Repository.Context;

namespace Pessoas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connections = new Connections()
            {
                ConnectionString = Configuration.GetValue<string>("ConnectionString"),
                ConnectionStringNoSql = Configuration.GetValue<string>("ConnectionStringNoSql"),
                BaseNoSql = Configuration.GetValue<string>("BaseNoSql"),
                CacheString = Configuration.GetValue<string>("CacheString"),
                ServiceBusHostName = Configuration.GetValue<string>("ServiceBusHostName")
            };

            DependencyInjection.Inject(services, connections);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
