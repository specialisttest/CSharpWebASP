using Microsoft.AspNetCore.Http;
using WebDI.Services;

namespace WebDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddSingleton<IHello, HelloImpl>();
            //builder.Services.AddSingleton<ICounter, CounterImpl>();
            builder.Services.AddScoped<ICounter, CounterImpl>();
            //builder.Services.AddTransient<ICounter, CounterImpl>();

            var app = builder.Build();

            

            /*app.Run(async context => {
                context.Response.ContentType = "text/html;charset=utf8";
                await context.Response.WriteAsync(app.Services.GetService<IHello>().GetHelloString());
            });*/

            app.UseMiddleware<HelloMiddleware>();

            app.Use(async (context, next) => {
                //var counter = app.Services.GetRequiredService<ICounter>(); // only Singleton or Transient
                var counter = context.RequestServices.GetRequiredService<ICounter>(); // Scoped
                counter.Increment();
                await context.Response.WriteAsync($"<h2>{counter.Get()}</h2>");

                await next();
            });

            app.Run();
        }
    }
}
