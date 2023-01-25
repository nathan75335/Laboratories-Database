using Library.DataAccess.Models;
using Library.DataAccess.Repositories;
using Library.DataAccess.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DataAccess.Extensions;

public static class AppDependenciesConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<BookContext>(options)
            .AddIdentity<User, Role>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<BookContext>();
        
        services
            .AddScoped(serviceProvider => serviceProvider.GetRequiredService<BookContext>().Set<Book>())
            .AddScoped(serviceProvider => serviceProvider.GetRequiredService<BookContext>().Set<Genre>())
            .AddScoped(service => service.GetRequiredService<BookContext>().Set<EditionHouse>())
            .AddScoped(service => service.GetRequiredService<BookContext>().Set<BorrowBook>())
            .AddScoped(service => service.GetRequiredService<BookContext>().Set<Worker>())
            .AddScoped(service => service.GetRequiredService<BookContext>().Set<Position>()); 
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IEditionHouseRepository, EditionHouseRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBorrowBookRepository, BorrowBookRepository>()
            .AddScoped<IWorkerRepository, WorkerRepository>()
            .AddScoped<IPositionRepository, PositionRepository>()
            .AddScoped<ISaveChangesRepository, SaveChangesRepository>()
            .AddScoped<SeedDataSexe>()
            .AddScoped<SeedGenresData>()
            .AddScoped<SeedPositionData>()
            .AddScoped<SeedDataAdministrator>()
            .AddScoped<SeedRoles>();
    }
}
