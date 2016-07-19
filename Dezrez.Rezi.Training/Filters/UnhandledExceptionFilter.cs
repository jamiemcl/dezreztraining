using System;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Web.Http;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.DataContracts.System;

namespace Dezrez.Rezi.Training.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute, IAutofacExceptionFilter
    {
        private readonly ILifetimeScope _lifetimeScope;

        public UnhandledExceptionFilter(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            IUnitOfWork unitOfWork = _lifetimeScope.Resolve<IUnitOfWork>();
            unitOfWork.Rollback();

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            Guid guid = Guid.NewGuid();

            if (context.Exception is HttpResponseException)
            {
                //Introduced in .NET 4.5 to retain the stacktrack when rethrowing exceptions. Handy!
                ExceptionDispatchInfo.Capture(context.Exception).Throw();
            }

            string details;
            try
            {
                details =
                    string.Format(
                        "Error occured whilst invoking action {0} on controller {1}. This error has been logged. Error: {2}",
                        context.ActionContext.ActionDescriptor.ActionName,
                        context.ActionContext.ControllerContext.Controller.GetType().Name,
                        context.Exception.Message);
            }
            catch (Exception)
            {
                details = "This error has been logged.";
            }

            ApiErrorDataContract content = new ApiErrorDataContract
            {
                Message = "An error has occurred. If this persists please contact us",
                ErrorReference = guid.ToString(),
                Details = details
            };

            context.Response = context.Request.CreateResponse(statusCode, content);
        }
    }
}