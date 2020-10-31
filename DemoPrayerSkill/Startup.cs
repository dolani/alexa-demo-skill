using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPrayerSkill.Abstract;
using DemoPrayerSkill.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemoPrayerSkill
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
            services.AddTransient<IAddPrayerIntentHandler, AddPrayerIntentHandler>();
            services.AddTransient<IViewPrayerIntentHandler, ViewPrayerIntentHandler>();
            services.AddTransient<ISavePrayerIntentHandler, SavePrayerIntentHandler>();
            services.AddTransient<ILaunchRequestHandler, LaunchRequestHandler>();
            services.AddTransient<IArchivePrayerIntentHandler, ArchivePrayerIntentHandler>();
            services.AddTransient<IClearPrayerIntentHandler, ClearPrayerIntentHandler>();
            services.AddTransient<IPrayerIntentHandler, PrayerIntentHandler>();
            services.AddTransient<IAmazonYesIntentHandler, AmazonYesIntentHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            loggerFactory.AddFile("Logs/myapp.log");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
