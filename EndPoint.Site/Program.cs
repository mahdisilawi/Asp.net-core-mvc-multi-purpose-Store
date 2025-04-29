using Hyper_Store.Application.Interfaces.Contexts;
using Hyper_Store.Application.Interfaces.FacadPatterns;
using Hyper_Store.Application.Services.Common.Queries.GetCategory;
using Hyper_Store.Application.Services.Common.Queries.GetMenuItem;
using Hyper_Store.Application.Services.Common.Queries.GetSlider;
using Hyper_Store.Application.Services.HomePages.Commands.AddNewHomePageImages;
using Hyper_Store.Application.Services.HomePages.Commands.AddNewSlider;
using Hyper_Store.Application.Services.Products.FacadPattern;
using Hyper_Store.Application.Services.Users.Commands.EditUser;
using Hyper_Store.Application.Services.Users.Commands.RegisterUser;
using Hyper_Store.Application.Services.Users.Commands.RemoveUser;
using Hyper_Store.Application.Services.Users.Commands.UserLogin;
using Hyper_Store.Application.Services.Users.Commands.UserSatusChange;
using Hyper_Store.Application.Services.Users.Queries.GetRoles;
using Hyper_Store.Application.Services.Users.Queries.GetUsers;
using Hyper_Store.Persistance.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Connecting to DataBase
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")   
   )
) ;

builder.Services.AddScoped<IApplicationDbContext,ApplicationDbContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginServices>();

//FacadeInject
builder.Services.AddScoped<IProductFacad, ProductFacad>();

//InjectGetMenuService
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
//InjectGetCategoryForSearchService
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
//InjectAddSlider
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
//-----
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddNewHomePageImagesService, AddNewHomePageImagesServicel>();


//AddingAuthenticationService
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();
