using CmsBlogWeb.Business.Configuration;
using CmsBlogWeb.Business.Services;
using CmsBlogWeb.Business.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CmsBlogWeb
{
    public class Startup
    {
        public readonly IWebHostEnvironment Environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var mvcBuilder = services.AddControllersWithViews();

            //if (Environment.IsDevelopment())
            //{
            //    mvcBuilder.AddRazorRuntimeCompilation();
            //}

            services.AddOrchardCms().ConfigureServices(services =>
            {
                services.AddTransient<IOrchardCoreContentService, OrchardCoreContentService>();
                services.AddTransient<IOrchardCoreUserService, OrchardCoreUserService>();
                services.AddTransient<ICmsBlogDbAccessService, CmsBlogDbAccessService>();

                services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));
                services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppSettings>>().Value);
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseOrchardCore();
        }
    }
}
