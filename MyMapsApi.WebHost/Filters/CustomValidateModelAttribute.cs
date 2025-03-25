using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MyMapsApi.Core.Models;

namespace MyMapsApi.WebHost.Filters;

/// <summary>
/// Кастомный аттрибут действия контроллера для обработки ошибок валидации
/// </summary>
public class CustomValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext actionContext)
    {
        if (!actionContext.ModelState.IsValid)
        {
            var loggerFactory = actionContext.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<CustomValidateModelAttribute>();

            var errorList = actionContext.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();

            foreach (var error in errorList)
            {
                logger.LogWarning(error);
            }

            var result = new OperationResult<string>(errorList, 400);

            actionContext.Result = new BadRequestObjectResult(result);
        }
    }
}