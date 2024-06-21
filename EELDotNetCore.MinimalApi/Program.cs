using EELDotNetCore.MinimalApi.Db;
using EELDotNetCore.MinimalApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
},
ServiceLifetime.Transient,
ServiceLifetime.Transient);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World");

app.MapGet("api/Blog", async (AppDbContext db) =>
{
    var lst = await db.Blogs.AsNoTracking().ToListAsync();
    return Results.Ok(lst);
});

app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
{
    await db.Blogs.AddAsync(blog);
    var result = await db.SaveChangesAsync();

    string message = result > 0 ? "Saving Successful." : "Saving Fail.";
    return Results.Ok(message);
});

app.MapPut("api/Blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
{
    var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogID == id);
    if (item is null)
    {
        return Results.NotFound("No data Found.");
    }

    item.BlogTitle = blog.BlogTitle;
    item.BlogAuthor = blog.BlogAuthor;
    item.BlogContent = blog.BlogContent;
    var result = await db.SaveChangesAsync();

    string message = result > 0 ? "Updating Successful." : "Updating Fail.";
    return Results.Ok(message);
});

app.MapDelete("api/Blog/{id}", async (AppDbContext db, int id) =>
{
    var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogID == id);
    if (item is null)
    {
        return Results.NotFound("No data Found.");
    }

   db.Blogs.Remove(item);
    var result = await db.SaveChangesAsync();

    string message = result > 0 ? "Deleting Successful." : "Deleting Fail.";
    return Results.Ok(message);
});

app.Run();
















//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
