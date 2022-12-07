using ASP.NetEmpty3.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetEmpty3
{
    public class Startup
    {


         public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
      
        public void ConfigureServices(IServiceCollection services) {
          
            services.AddMvc();
            services.AddSingleton<IEmployeeRepository, MockEmployeeDetails>();
           services.AddMvc().AddXmlDataContractSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {

               //app.UseStatusCodePagesWithRedirects("/Error/{ 0}");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");      //404status
                app.UseExceptionHandler("/Error1/{0}");   
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute (name: "default",
                     pattern: "{controller=Home}/{action=Details}/{id?}");
            });

          
        }
    }
}
