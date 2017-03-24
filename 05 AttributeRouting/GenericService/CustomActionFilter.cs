using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace GenericService
{
    public class CustomActionFilter : IAutofacActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger logger)
        {
            this._logger = logger;
        }

        ////?
        //public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    this._logger.Write("Inside the 'OnActionExecutedAsync' method of the custom action filter.");
        //    return Task.FromResult(0);
        //}

        ////?
        //public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        //{
        //    this._logger.Write("Inside the 'OnActionExecutingAsync' method of the custom action filter.");
        //    return Task.FromResult(0);
        //}

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            this._logger.Write("Inside the 'OnActionExecuting' method of the custom action filter.");
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            this._logger.Write("Inside the 'OnActionExecuted' method of the custom action filter.");
        }
    }
}