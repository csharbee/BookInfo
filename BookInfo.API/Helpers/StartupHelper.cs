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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;

namespace BookInfo.API.Helpers
{
    public static class StartupHelper
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<BookNotFoundFilter>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var errorResponse = new ResponseDto();
                        var ex = errorFeature.Error;
                        errorResponse.Errors.Add(ex.Message);
                        errorResponse.Success = false;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                    }
                });
            });
        }

        public static void UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                        .WithOrigins("http://localhost:1234")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        }
    }
}
