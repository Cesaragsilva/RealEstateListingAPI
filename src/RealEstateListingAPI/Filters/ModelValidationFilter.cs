using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealEstateListing.Api.Filters
{
    public class ModelValidationFilter<T>(IValidator<T> validator) : IAsyncActionFilter where T : class
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.TryGetValue(typeof(T).Name.ToLower(), out var value) && value is T entity)
            {
                var result = await validator.ValidateAsync(entity, context.HttpContext.RequestAborted);

                if (!result.IsValid)
                {
                    result.Errors.ForEach(message => context.ModelState.AddModelError("errors", message.ErrorMessage));

                    context.Result = new BadRequestObjectResult(context.ModelState);
                    return;
                }
            }

            await next();
        }
    }
}
