using Microsoft.AspNetCore.Mvc.Filters;

namespace Day05.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Before Action Method");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("After Action Method");
        }
    }
}