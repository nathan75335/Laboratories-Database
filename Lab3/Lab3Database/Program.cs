using Lab3.DataAccessLayer;
using Lab3.DataAccessLayer.Models;
using Lab3.DataAccessLayer.Repositories;
using Lab3Database;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped(serviceProvider => serviceProvider.GetRequiredService<BookContext>().Set<Book>());
builder.Services.AddScoped(serviceProvider => serviceProvider.GetRequiredService<BookContext>().Set<Genre>());
builder.Services.AddScoped(serviceProvider => serviceProvider.GetRequiredService<BookContext>().Set<EditionHouse>());
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
Console.WriteLine(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
builder.Services.AddScoped<IRepository<EditionHouse>, Repository<EditionHouse>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseResponseCaching();

app.MapGet("/",async(context) =>
{
	context.Response.ContentType = "text/html; charset=UTF-8;";
	var result = new StringBuilder("");

	result.Append("<p><a href=\"/home/genres\">Go to genres</a></p>");
	result.Append("<p><a href=\"/home/books\">Go to books</a></p>");
	result.Append("<p><a href=\"/home/editionhouses\">Go to edition Houses</a></p>");

	await context.Response.WriteAsync(result.ToString());

});

app.Map("/home", home =>
{
    home.Map("/genres", CachService.HandleGenre);
    home.Map("/editionhouses", CachService.HandleEditionHouse);
    home.Map("/books", CachService.HandleBook);
});


app.MapGet("/searchform1", async (context) =>
{
	context.Response.ContentType = "text/html; charset=UTF-8;";
	var inCookie = context.Request.Cookies;
	var outCookies = context.Response.Cookies;

	string len = inCookie["L"];
	string rat = inCookie["R"];
	string gen = inCookie["G"];

	var result = new StringBuilder("<h3>Поиск :</h3><form action=\"/searchform1\">");

	result.Append("<p>Введите the book:</p>");

	if (len != null)
	{
		result.Append($"<p><input name=\"L\" value=\"{len}\"></p>");
	}
	else
	{
		result.Append($"<p><input name=\"L\"></p>");
	}
	result.Append("<p>Выбрать только book with genre romance>");

	if (rat == "YES")
	{
		result.Append($"<p><input checked name=\"R\" type=\"radio\" value=\"YES\"></p>");
	}
	else
	{
		result.Append($"<p><input name=\"R\" type=\"radio\" value=\"YES\"></p>");
	}


	result.Append("<p>Выберите жанр:</p>");
	result.Append("<select name=\"G\"");

	var items = context.RequestServices.GetRequiredService<IRepository<Genre>>().GetAll("Genre20");

	foreach (var item in items)
	{
		if (gen != null && item.Name == gen)
		{
			result.Append($"<option selected>{item.Name}<option>");
		}
		else
		{
			result.Append($"<option>{item.Name}<option>");
		}
	}

	result.Append("</select>");
	result.Append("<input type=\"submit\" value=\"Отправить\"/></form>");

	result.Append("<p><a href=\"/\">Назад</a></p>");

	string L = context.Request.Query["L"];
	string R = context.Request.Query["R"];
	string G = context.Request.Query["G"];

	if (L is not null)
	{
		outCookies.Append("L", context.Request.Query["L"]);
	}
	if (R is not null)
	{
		outCookies.Append("R", context.Request.Query["R"]);
	}
	if (G is not null)
	{
		outCookies.Append("G", context.Request.Query["G"]);
	}

	await context.Response.WriteAsync(result.ToString());
});


app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();


app.Run();


