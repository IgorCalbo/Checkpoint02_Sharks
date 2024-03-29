using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sharks.Checkpoint02.Persistencias;
using Sharks.Checkpoint02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharks.Checkpoint02
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
            services.AddControllersWithViews();

            //Configurar a inje��o de depend�ncia do DbContext, "conexao" -> appsettings.json
            services.AddDbContext<SharksContext>(op =>
               op.UseSqlServer(Configuration.GetConnectionString("conexao")));

            //Configurar a inje��o de depend�ncia dos Repositories
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IEscritorRepository, EscritorRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<ILivroEscritorRepository, LivroEscritorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
