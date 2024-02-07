﻿using WebDI.Services;

namespace WebDI
{
    public class HelloMiddleware
    {
        private RequestDelegate _next;
        //private IHello helloSrv;

        public HelloMiddleware(RequestDelegate next/*, IHello hello*/ /*only Singleton or Transient*/)
        {
            this._next = next;
            //this.helloSrv = hello;
        }

        public async Task Invoke(HttpContext context, IHello helloSrv3, ICounter counterSrv)
        {
            context.Response.ContentType = "text/html;charset=utf8";

            // ctor
            //await context.Response.WriteAsync(helloSrv.GetHelloString());

            // context
            //IHello helloSrv2 = context.RequestServices.GetRequiredService<IHello>();
            //await context.Response.WriteAsync(helloSrv2.GetHelloString());

            counterSrv.Increment();
            await context.Response.WriteAsync(helloSrv3.GetHelloString() + " " + counterSrv.Get().ToString());
            
            
            //await context.Response.WriteAsync(helloSrv3.GetHelloString());

            await _next(context);
        }
    }
}
