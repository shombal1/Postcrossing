using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Postcrossing.Api.Middleware;

public class ErrorHandingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context,ProblemDetailsFactory problemDetailsFactory)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            ProblemDetails problemDetails;
            
            switch (e)
            {
                case ValidationException validationException:
                    problemDetails = problemDetailsFactory.CreateFrom(context, validationException);
                    break;
                default:
                    problemDetails = problemDetailsFactory.CreateProblemDetails(
                        context,
                        StatusCodes.Status500InternalServerError,
                        "Unhandled exception",
                        detail: e.Message);
                    break;
            }

            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType());
        }
    }
}