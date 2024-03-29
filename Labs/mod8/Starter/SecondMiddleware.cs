//using Microsoft.AspNetCore.Http;

public class SecondMiddleware {
    RequestDelegate _next;
    public SecondMiddleware(RequestDelegate next) { _next=next; }

    public async Task Invoke(HttpContext context) {
        await _next(context);
        await context.Response.WriteAsync($" Status code={context.Response.StatusCode} ");
    }
}