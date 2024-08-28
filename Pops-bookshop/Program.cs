using Microsoft.EntityFrameworkCore;
using Pops_bookshop.Models.Entities;
using Pops_bookshop.Areas.Identity.Data;
using Pops_bookshop.Repositories.Interfaces;
using Pops_bookshop.Repositories;
using Pops_bookshop.Services;
using Pops_bookshop.Services.Interfaces;

namespace Pops_bookshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("PopsBookshopContextConnection") ?? throw new InvalidOperationException("Connection string 'PopsBookshopContextConnection' not found.");

            // Set up the database with EntityFramework
            builder.Services.AddDbContext<BookshopDbContext>(options => options.UseSqlServer(connectionString));

            // Set up Identity
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BookshopDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IWishlistService, WishlistService>();
            builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
