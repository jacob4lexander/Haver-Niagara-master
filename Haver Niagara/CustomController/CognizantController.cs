using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Haver_Niagara.CustomController
{
    public class CognizantController : Controller
    {
        internal string ControllerName()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }
        internal string ActionName()
        {
            return ControllerContext.RouteData.Values["action"].ToString();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["ControllerName"] = ControllerName();
            ViewData["ActionName"] = ActionName();
            ViewData["Title"] = ControllerName() + " " + ActionName();
            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            ViewData["ControllerName"] = ControllerName();
            ViewData["ActionName"] = ActionName();
            ViewData["Title"] = ControllerName() + " " + ActionName();
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
