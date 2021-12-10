using System;
using PortfolioProject2.Models.DataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using PortfolioProject2.Models;
using WebApplication.DataInterfaces;
using WebApplication.DataServices;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;
using UserDataService = WebApplication.DataServices.UserDataService;

namespace WebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSingleton<ITitlesDataService, TitleDataService>();
            services.AddSingleton<IActorDataService, ActorDataService>();
            services.AddSingleton<IOmdbDataService, OmdbDataService>();
            services.AddSingleton<IRatings, RatingsDataService>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<ICommentsDataService, CommentsDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
            
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}