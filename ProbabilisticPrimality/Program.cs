using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "Probabilistic Primality Test";
    settings.Version = "v1";
    settings.Description = "Primality test using witness numbers. Witness numbers are numbers that declare whether an odd" +
                           "integer greater than 2 is prime or composite.";
});
var app = builder.Build();

app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.UseHttpsRedirection();

app.Run();