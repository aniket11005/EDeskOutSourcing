using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace EDeskOutSourcing.CustFilters
{
    public class FreelancerAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if(context.HttpContext.Session.GetString("FreelancerID")==null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action ="SignIn",controller="ManageFreelancer",area=""}));
            }
        }
    }
}
