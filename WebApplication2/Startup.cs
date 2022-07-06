using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ////A cada chamada sempre cria uma nova instancia
            //services.AddTransient<ICatalogo, Catalogo>();
            //services.AddTransient<IRelatorio, Relatorio>();

            //sempre obter uma nova instancia para cada requisicao que for feita no navegador
            services.AddScoped<ICatalogo, Catalogo>();
            services.AddScoped<IRelatorio, Relatorio>();

            //sempre trabalha com a unica instancia de um servico que foi solicitado
            //var catalogo = new Catalogo();
            //services.AddSingleton<ICatalogo>(new Catalogo());
            //services.AddSingleton<IRelatorio>(new Relatorio(new Catalogo()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
