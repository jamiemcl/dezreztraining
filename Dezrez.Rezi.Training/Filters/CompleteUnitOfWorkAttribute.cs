using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.DataContracts.System;
using NHibernate;

namespace Dezrez.Rezi.Training.Filters
{
    public class CompleteUnitOfWorkAttribute : IAutofacActionFilter
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CompleteUnitOfWorkAttribute(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            IUnitOfWork unitOfWork = _lifetimeScope.Resolve<IUnitOfWork>();

            if (unitOfWork == null)
            {
                return;
            }

            if (actionExecutedContext.Exception == null)
            {
                try
                {
                    unitOfWork.Complete();
                }
                catch (StaleObjectStateException stateEx)
                {
                    var guid = Guid.NewGuid();

                    var content = new ApiErrorDataContract
                    {
                        Message = "An error has occurred. If this persists please contact us",
                        ErrorReference = guid.ToString(),
                        Details = string.Format(
                            "EntityName: {0}, Id: {1}, Concurrency error occured whilst invoking action {2} on controller {3}. Reload the data and try again. This error has been logged.",
                            stateEx.EntityName,
                            stateEx.Identifier,
                            actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                            actionExecutedContext.ActionContext.ControllerContext.Controller.GetType().Name)
                    };

                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.Conflict, content);
                }
            }
            else
            {
                unitOfWork.Rollback();
            }
        }
    }
}