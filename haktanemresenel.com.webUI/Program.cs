using haktanemresenel.com.core.Services;
using haktanemresenel.com.webUI.Extensions;
using haktanemresenelk.com.services.Services;
using haktanemresenel.com.repository;
using haktanemresenel.com.repository.Repository;   
using AppContext =  haktanemresenel.com.repository.Repository.contexts.AppContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); 
        });
});


builder.Services.CustomServices();
 
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{Ğ
    options.Cookie.Name = ".LandingAdminPage";
    options.IdleTimeout = TimeSpan.FromDays(60);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAutoMapper(config =>
{
    MapperConfigsExtensions.AddMapperConfig(config);
});

builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.CustomMiddlewares();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
