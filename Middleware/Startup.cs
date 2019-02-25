using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //Configura serviços 
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /*Exemplo de injeção de dependências 
                Cria uma interface para a classe PeopleRepository com uma instância que atribui 
                a String de conexão para cada invocação.
                services.AddTransient<IPeopleRepository>(repository => new PeopleRepository("http://sqlserver"));
                services.AddScoped() cria uma instância para cada requisição (uma requisição pode usar várias classes)
                services.AddSingleTon() cria apenas uma instância para a aplicação 
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //Configura Middlewares
        {
            //Ambientes de desenvolvimento: Production, Development e Staging
            Console.WriteLine($"Banco {Configuration["ConnectionString"]}");

            //Verifica se a aplicação está em modo de desenvolvedor para mostrar ou não a página de exceções
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Habilita os arquivos estáticos na aplicação Web (IMG/CSS/JS) presentes na pasta wwwroot
            app.UseStaticFiles();

            //Habilita os cookies na aplicação WEB
            app.UseCookiePolicy();

            //Middleware responsável pelo funcionamento do MVC 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
