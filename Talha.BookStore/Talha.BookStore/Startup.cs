namespace Talha.BookStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
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
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Second middleware!\n");
            //    await next();
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!\n");
            //    });
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/Talha", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello From Talha\n");
            //    });
            //});
        }
    }
}