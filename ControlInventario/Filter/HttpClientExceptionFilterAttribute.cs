using Microsoft.AspNetCore.Mvc.Filters;
using ControlInventario.Datos.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CuadroMando.WebApi.Filter;
public class HttpClientExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is InvalidOperationException
            || context.Exception is InvalidDataException)
        {
            context.Result = new JsonResult(new DtoBaseResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false,
                Message = string.IsNullOrEmpty(context.Exception.Message) ? "Ha ocurrido un error inesperado" : context.Exception.Message
            });
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            context.Result = new JsonResult(new DtoBaseResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Success = false,
                Message = "Ha ocurrido un error inesperado " + context.Exception + context.Exception.StackTrace
            });
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        base.OnException(context);
    }
}