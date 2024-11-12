using Ardalis.GuardClauses;

namespace OnlineShopping.CatalogService.WebApi;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = StatusCodes.Status404NotFound;
        }
    }

}
