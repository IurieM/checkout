using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using Identity.Api.Validators;
using Microsoft.AspNetCore.Mvc;
using Checkout.Api.Infrastructure.Filters;
using Checkout.Common.Infrastructure.Extensions;
using MediatR;
using System.Reflection;
using Identity.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Identity.Data.Seed;
using Identity.Api.Settings;

namespace Identity.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.Configure<AuthenticationSettings>(Configuration.GetSection("AuthenticationSettings"));
            ConfigureDatabase(services);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelValidationFilter));

            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthenticateUserCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseCors("AllowAllOrigins");
            SeedDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();
            app.UseMvc();
        }

        private void SeedDatabase(IApplicationBuilder app)
        {
            //Setup Databases
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IIdentityDbContext>();

                dbContext.Users.AddRange(IdentitySeed.Users);
                dbContext.SaveChangesAsync().Wait();
            }
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseInMemoryDatabase("Identity").ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
            services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        }
    }
}
