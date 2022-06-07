using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using WM.CrossCutting.Helper;

namespace WorkManagerAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception exception)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ContractResponse responseBody;
            context.Response.Clear();

            responseBody = exception switch
            {
                ValidationException validacoes => SetBadRequestMessage(validacoes),
                UnauthorizedAccessException acessoNegado => SetBadRequestMessage(acessoNegado.Message),
                InvalidOperationException mediatrException => SetBadRequestMessage(mediatrException.Message),
                _ => SetBadRequestMessage(exception.InnerException?.Message ?? exception.Message)
            };

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "application/json";

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = (Formatting)System.Xml.Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody));
        }

        private static ContractResponse SetBadRequestMessage(ValidationException ex)
        {
            return new ContractResponse(false, "Ops...Foi encontrado um erro.", new { erros = ex.Errors.Select(x => x.ErrorMessage) });
        }

        private static ContractResponse SetBadRequestMessage(string ex)
        {
            return new ContractResponse(false, "Ops...Foi encontrado um erro.", new { erros = new List<string>() { ex } });
        }
    }
}
