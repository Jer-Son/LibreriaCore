using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using TestDb.Data;
using TestDb.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbContext") ?? throw new InvalidOperationException("Connection string 'TestDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//agregar context a clase

builder.Services.AddScoped<EditorialRepository>();
builder.Services.AddScoped<EditorialService>();
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<LibroRespository>();
builder.Services.AddScoped<LibroService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
