using EntityModel.Models;
using EntityModel.Repositories;
using EntityModel.Services;
using Microsoft.EntityFrameworkCore;
using MVCVitrine.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region DBCONTEXT
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IGenericReadOnlyRepository<Category>, GenericReadOnlyRepository<Category>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Enterprise>, GenericReadOnlyRepository<Enterprise>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Goal>, GenericReadOnlyRepository<Goal>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Job>, GenericReadOnlyRepository<Job>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Skill>, GenericReadOnlyRepository<Skill>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Training>, GenericReadOnlyRepository<Training>>();
builder.Services.AddScoped<IGenericReadOnlyRepository<Training>, GenericReadOnlyRepository<Training>>();
builder.Services.AddScoped<IGenericReadonlyService<Category>, GenericReadonlyService<Category>>();
builder.Services.AddScoped<IGenericReadonlyService<Enterprise>, GenericReadonlyService<Enterprise>>();
builder.Services.AddScoped<IGenericReadonlyService<Goal>, GenericReadonlyService<Goal>>();
builder.Services.AddScoped<IGenericReadonlyService<Job>, GenericReadonlyService<Job>>();
builder.Services.AddScoped<IGenericReadonlyService<Skill>, GenericReadonlyService<Skill>>();
builder.Services.AddScoped<IGenericReadonlyService<Training>, GenericReadonlyService<Training>>();
#endregion
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
