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
                        var ex = errorFeature.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = HttpStatusCode.InternalServerError;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
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
