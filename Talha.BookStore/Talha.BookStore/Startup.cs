using Microsoft.EntityFrameworkCore;
using Talha.BookStore.Data;
using Talha.BookStore.Repositry;

namespace Talha.BookStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=TALHAH-SKILLED-\\SQLEXPRESS;Database=BookStore;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"));

            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

            services.AddScoped<BookRepositry, BookRepositry>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from First middleware!\n");
            //    await next();
            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "bookapp/{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!\n");
            //    });
            //});
        }
    }
}