using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace curso
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Forma antiga de se criar o Hosting
            var host = new WebHostBuilder()
            .UseKestrel()
            .Configure(app =>{
                app.Run(context => context.Response.WriteAsync("Bem vindo ao curso massa :)"));
            })
            .UseStartup<Startup>()
            .Build();
            */
            //Nova nomenclatura
            var host = WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
            host.Run();
        }
    }

    internal class Startup
    {
        private IConfiguration _configuration;

        public Startup (IConfiguration configuration){
            _configuration = configuration;
        }
        public void Configure(IApplicationBuilder app){
            var ordem = String.Empty;
            // A ordem do Middleware é importante para a execução das tarefas
            app.Use(async (context,next) =>{
                //Ordem 2
                ordem +="2";
                await next.Invoke();
                //Ordem 3
                ordem +="3";
            } );
            app.Use(async (context,next) =>{
                //Ordem 1
                ordem +="1";
                await next.Invoke();
                //Ordem 4
                ordem +="4";
                await context.Response.WriteAsync(/*_configuration["Application"]*/$"Ordem: {ordem}");
            } );
        }
    }
}
