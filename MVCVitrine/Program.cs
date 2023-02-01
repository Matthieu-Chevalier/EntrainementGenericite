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

builder.Services.AddScoped<DbContext, AppDbContext>(); //<------- Attention, il ne faut pas oublier l'injection de dépendance du DBcontext dans le constructeur des repo


builder.Services.AddScoped<IGenericRepository<AbstractEntity>, GenericRepository<AbstractEntity>>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<Enterprise>, GenericRepository<Enterprise>>();
builder.Services.AddScoped<IGenericRepository<Goal>, GenericRepository<Goal>>();
builder.Services.AddScoped<IGenericRepository<Job>, GenericRepository<Job>>();
builder.Services.AddScoped<IGenericRepository<Skill>, GenericRepository<Skill>>();
builder.Services.AddScoped<IGenericRepository<Training>, GenericRepository<Training>>();
//builder.Services.AddScoped<IGenericService<AbstractEntity>, GenericService<AbstractEntity>>();



#endregion

#region MailService

var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Add(new ServiceDescriptor(typeof(EmailSettings),
    c => new EmailSettings()
    {
        Mail = mailSettings.GetValue<string>("Mail"),
        DisplayName = mailSettings.GetValue<string>("DisplayName"),
        Password = mailSettings.GetValue<string>("Password"),
        Host = mailSettings.GetValue<string>("Host"),
        Port = mailSettings.GetValue<int>("Port")
    }, ServiceLifetime.Transient

    ));
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
