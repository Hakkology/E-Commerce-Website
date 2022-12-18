using BuyFS.Entity.POCO;
using Commerce.BusinessLogicLayer.Abstract;
using Commerce.BusinessLogicLayer.Concreate;
using MerchantFS.DataAccessLayer.Abstract;
using MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework;
using Patrician.WebApp.CustomValidation;

namespace Patrician.WebApp.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            //AddScoped allows us to add services as in Categories as follows.
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategory>();
            //Product Manager Added with AddScoped
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EfProduct>();
            //Basket Manager Added with AddScoped
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDAL, EfBasket>();
            //Database added as service
            services.AddDbContext<MarketDbContext>();
            //Registration services with error describer
            services.AddIdentity<AppClient, AppRoles>(x =>
            {
                x.Password.RequiredLength = 6;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.User.RequireUniqueEmail = true;
            }).AddErrorDescriber<ErrorDiscriberAccount>()
            .AddEntityFrameworkStores<MarketDbContext>();

            //cookie setup
            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.HttpOnly = true;
                x.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                x.Cookie.MaxAge = TimeSpan.FromDays(1);
            });
            //For chaining calls
            services.AddSession();

            //AddControllerWithViews dictates MVC Structure for current project.
            services.AddControllersWithViews();

            //builder.Services.AddTransient helps you add service, and whenever that service is called, you may create multiple objects.
            //builder.Services.AddSingleton helps you add service, and no matter how many times that service is called, only one object is created.
            return services;
        }
    }
}
