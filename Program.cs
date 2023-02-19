using Microsoft.EntityFrameworkCore;
using my_new_app.Data;
using my_new_app.DataAccess.Interfaces;
using my_new_app.DataAccess.Services;
using my_new_app.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<AgeCalculator>();
builder.Services.AddScoped<IAgeCalculator, AgeCalculator>();
builder.Services.AddSingleton<CategoryMapper>();
builder.Services.AddScoped<ICategoryMapper, CategoryMapper>();
builder.Services.AddSingleton<CategoryFactory>();
builder.Services.AddScoped<ICategoryFactory, CategoryFactory>();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepositoryBase<Person>, RepositoryBase<Person>>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddDbContext<PersonContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
