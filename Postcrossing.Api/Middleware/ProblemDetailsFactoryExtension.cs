using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Postcrossing.Api.Middleware;

public static class ProblemDetailsFactoryExtension
{
    public static ProblemDetails CreateFrom(this ProblemDetailsFactory problemDetailsFactory, HttpContext context,
        ValidationException validationException)
    {
        ModelStateDictionary stateDictionary = new ModelStateDictionary();
        foreach (var error in validationException.Errors)
        {
            stateDictionary.AddModelError(error.PropertyName,error.ErrorMessage);
        }
        return problemDetailsFactory.CreateValidationProblemDetails(
            context,stateDictionary,StatusCodes.Status400BadRequest,"Bad request");
    }
}