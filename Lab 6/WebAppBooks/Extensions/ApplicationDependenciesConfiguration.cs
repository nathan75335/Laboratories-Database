using BusinessLogic.Services;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using WebAppBooks.Profiles;

namespace WebAppBooks.Extensions
{
    /// <summary>
    /// Configuration of all the dependencies of the application
    /// </summary>
    public static partial class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Configure all the services of the application
        /// </summary>
        /// <param name="builder">The builder</param>
        /// <returns>A <see cref="WebApplicationBuilder"/></returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddBookDbContext(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")))
                .AddLogging()
                .AddRepositories()
                .AddAutoMapper(typeof(MapperProfiles))
                .AddScoped<IBookService, BookService>()
                .AddCors(options =>
                {
                    options.AddPolicy(name: "AllowedOrigin", policy =>
                    {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
                });
                
            return builder;
        }
    }
}
