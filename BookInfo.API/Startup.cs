using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.API.DTOs;
using BookInfo.API.Filters;
using BookInfo.Core;
using BookInfo.Core.Repositories;
using BookInfo.Core.Services;
using BookInfo.Data;
using BookInfo.Data.Repositories;
using BookInfo.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft;
using Newtonsoft.Json;

namespace BookInfo.API
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
            services.AddDbContext<MainContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionString:DefaultConnection"].ToString(), o =>
                 {
                     o.MigrationsAssembly("BookInfo.Data");
                 });
            });
            services.AddScoped<BookNotFoundFilter>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidationFilter());
            }).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }

                });
            }

            );
            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                    .WithOrigins("http://localhost:1234")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
