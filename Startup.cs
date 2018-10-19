using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMQuota.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HMQuota.Services;

namespace HMQuota
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<HMQuotaDBContext>(dbContextOptions => dbContextOptions.UseSqlite(Configuration["DBConnectionStr:DBStr"]));
            services.AddTransient<IQuotaHeaderService, QuotaHeaderService>();
            services.AddCors(options => options.AddPolicy("quota", builder => builder.WithOrigins("*", "*", "*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("Access-Control-Allow-Origin", "*")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("quota");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

        }
    }
}
