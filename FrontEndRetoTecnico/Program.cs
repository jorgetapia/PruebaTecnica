using Library.Application.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configuración de Entity Framework Core con SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

// Database
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlite("Data Source=books.db");
var context = new ApplicationDbContext(optionsBuilder.Options);
context.Database.EnsureCreated();

// Inyección de dependencias
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();
// Services
var services = new ServiceCollection()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
    })   
    .AddDbContextPool<ApplicationDbContext>(options => options.UseSqlite("Data Source=books.db"))
    .BuildServiceProvider();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
