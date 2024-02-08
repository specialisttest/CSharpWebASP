using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IHello, HelloImpl>();
            builder.Services.AddSingleton<ICourseData, CourseDataImpl>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // by default
            //else
            //    app.UseDeveloperExceptionPage();

            //app.UseStatusCodePages();
            //app.UseStatusCodePagesWithReExecute("/Home/ErrorEx?statuscode={0}");


            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "search",
                pattern: "search/{search}", 
                defaults: new { controller = "Course", action = "Search"});


            //controller/action/
            //My/Index
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
