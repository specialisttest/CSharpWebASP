namespace WebHello
{
    public class SecondMiddleware
    {
        private RequestDelegate _next;
        public SecondMiddleware(RequestDelegate next)
        { 
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Status code ={context.Response.StatusCode}");
            // if ....
            await _next(context);
        }

    }
}
