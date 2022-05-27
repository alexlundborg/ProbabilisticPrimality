using FastEndpoints;
using FastEndpoints.Swagger;
using NSwag.AspNetCore;
using ProbabilisticPrimality.Contracts.Responses;
using ProbabilisticPrimality.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "Probabilistic Primality Test";
    settings.Version = "v1";
    settings.Description = "Primality test using witness numbers. Witness numbers are numbers that testify to whether an odd integer greater than 3 is prime or composite.";
});
var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s =>
{
    s.ConfigureDefaults();
    s.CustomStylesheetPath = "/swagger-ui/SwaggerDark.css";
});

app.UseStaticFiles();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if (!context.Request.Path.Value!.Contains("/swagger", StringComparison.OrdinalIgnoreCase))
    {
        context.Response.Redirect("swagger");
        return;
    }

    await next();
});

app.Run();