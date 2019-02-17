using Ametista.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Ametista.Api.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        private readonly ValidationNotificationHandler notificationHandler;

        public ValidateModelStateAttribute(ValidationNotificationHandler notificationHandler)
        {
            this.notificationHandler = notificationHandler ?? throw new ArgumentNullException(nameof(notificationHandler));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (notificationHandler.Notifications.Any())
            {
                context.Result = new BadRequestObjectResult(notificationHandler.Notifications);
            }
        }
    }
}
