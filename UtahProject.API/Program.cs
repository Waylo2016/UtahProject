using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using UtahProject.Api.Data;
using UtahProject.Api.Models;
using UtahProject.ServiceDefaults;

namespace UtahProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int majorVersion = 1;
            const int minorVersion = 0;
            var apiVersion = new ApiVersion(majorVersion, minorVersion);
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServiceDefaults();

            builder.AddNpgsqlDbContext<ApplicationDbContext>(connectionName: "UtahDb");

            // Add services to the container.
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddApiVersioning(options =>
                    {
                        options.DefaultApiVersion = apiVersion;
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.ReportApiVersions = true;
                        options.ApiVersionReader = new UrlSegmentApiVersionReader();
                    }
                )
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV"; // format: 'v'major[.minor][.patch]
                    options.SubstituteApiVersionInUrl = true;
                }).AddMvc();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddIdentity<UserModel, IdentityRole<Guid>>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Utah Project API",
                    Version = "v1",
                    Description = "The API for the Utah Project Roleplay website",
                    Contact = new OpenApiContact
                    {
                        Name = "Ari - website developer",
                        Email = "Waylo@waylo.tech",
                        Url = new Uri("https://waylo.tech")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache-2.0",
                        Url = new Uri("https://opensource.org/license/apache-2.0")
                    },
                    Summary = "General API for the Utah Project. Will contain basic CRUD functionality, but will expand over time. No API is set in stone, except for exceptionally basic CRUD functionality"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}