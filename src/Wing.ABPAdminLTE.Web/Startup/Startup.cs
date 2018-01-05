﻿using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Wing.ABPAdminLTE.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wing.ABPAdminLTE.Identity;
using Wing.ABPAdminLTE.Web.Resources;
<<<<<<< HEAD
using Wing.ABPAdminLTE.Authentication.JwtBearer;
=======
>>>>>>> fe8cabbdd01669f3ce526ba7899a1ea2f8ea1478

namespace Wing.ABPAdminLTE.Web.Startup
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<ABPAdminLTEDbContext>(options =>
            {
                ABPAdminLTEDbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            IdentityRegistrar.Register(services);

<<<<<<< HEAD
			services.AddScoped<IWebResourceManager, WebResourceManager>();

			//Configure Abp and Dependency Injection
			return services.AddAbp<ABPAdminLTEWebModule>(options =>
=======
            services.AddScoped<IWebResourceManager, WebResourceManager>();

            //Configure Abp and Dependency Injection
            return services.AddAbp<ABPAdminLTEWebMvcModule>(options =>
>>>>>>> fe8cabbdd01669f3ce526ba7899a1ea2f8ea1478
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; });  //Initializes ABP framework.
            app.UseAbpRequestLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
<<<<<<< HEAD


			app.UseAuthentication();
			app.UseJwtTokenMiddleware();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "defaultWithArea",
					template: "{area}/{controller=Home}/{action=Index}/{id?}");

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
=======
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
>>>>>>> fe8cabbdd01669f3ce526ba7899a1ea2f8ea1478
    }
}
