using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobileProviderSystem.Enums;
using MobileProviderSystem.AdditionalOptions;
using MobileProviderSystem.Controllers.Requirements;
using MobileProviderSystem.Data;

namespace MobileProviderSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorizationHandler, RoleHandler>();

            services.AddDbContext<MobileProviderContext>(options =>
                {
                    options.UseMySql(this.Configuration
                            .GetSection(SectionNames.Sections[SectionKeys.Connections])
                            .GetSection(this.Configuration.
                                GetSection(SectionNames.Sections[SectionKeys.DataBases]).
                                GetSection(SectionNames.Sections[SectionKeys.MobileProviderDataBase]).Value).Value,
                        new MySqlServerVersion(new Version(8, 0, 27)));
                }
            );
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString(this.Configuration.GetSection(SectionNames.Sections[SectionKeys.Routes])
                        .GetSection(SectionNames.Sections[SectionKeys.AuthorizationRoute]).Value.Substring(1));
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString(this.Configuration.GetSection(SectionNames.Sections[SectionKeys.Routes])
                        .GetSection(SectionNames.Sections[SectionKeys.ErrorRoute]).Value);
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.RoleRequirement,
                    policy => policy.Requirements.Add(new RoleRequirement()));
            });
            
            services.AddControllersWithViews();
            
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(this.Configuration.GetSection(SectionNames.Sections[SectionKeys.Routes])
                    .GetSection(SectionNames.Sections[SectionKeys.ErrorRoute]).Value);
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:
                    SectionNames.Sections[SectionKeys.DefaultRoute],
                    pattern: this.Configuration.GetSection(SectionNames.Sections[SectionKeys.Routes])
                        .GetSection(SectionNames.Sections[SectionKeys.DefaultRoute]).Value);
            });
        }
    }
}