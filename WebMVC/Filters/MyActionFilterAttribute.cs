using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            Console.WriteLine("ActionExecuting");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"ActionExecuted. Result: {context.Result}");
        }
    }
}
