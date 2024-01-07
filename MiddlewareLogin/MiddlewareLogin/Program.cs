
using Middlewares.LoginMiddlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Invoking login middleware
app.UseLoginMiddleware();

app.MapPost("/", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Successful login");
});

app.Run();
