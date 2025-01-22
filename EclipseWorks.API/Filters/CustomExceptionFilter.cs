using EclipseWorks.DTO.BaseDTO;
using EclipseWorks.Helper;
using EclipseWorks.Helper.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EclipseWorks.API.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var contextExceptionMessage = context.Exception.Message;

            if (context.Exception.Data.Contains("SqlQuery"))
                contextExceptionMessage += $" - Query SQL: {context.Exception.Data["SqlQuery"]}";

            if (context.Exception.Data.Contains("JsonResult"))
                contextExceptionMessage += $" - JSON Result: {context.Exception.Data["JsonResult"]}";

            if (context.Exception is CustomException)
                _logger.LogWarning(context.Exception, contextExceptionMessage);
            else if (context.Exception is ApiException)
            {
                var errorContent = ((ApiException)context.Exception).Content;
                _logger.LogWarning(context.Exception, $"{context.Exception.Message} - Content: {errorContent}");
            }
            else
                _logger.LogError(context.Exception, contextExceptionMessage);

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = context.Exception is CustomException ? 400 : 500;
            var message = context.Exception is CustomException ? context.Exception.Message : Message.MSG0031;

            var result = new APIResponseDTO<ErrorDTO>
            {
                Errors = [message],
            };

            context.Result = new JsonResult(result);
            context.ExceptionHandled = true;

            base.OnException(context);
        }
    }
}
