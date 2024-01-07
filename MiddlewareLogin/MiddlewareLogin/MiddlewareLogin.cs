
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Middlewares.LoginMiddlewares
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            List<string> messagesErrorsFields = new List<string>();
            string? email = null;
            string? password = null;
            string defaultMissingFieldString = "Invalid input for ";
            bool hasEmail = queryDict.ContainsKey("email") && !string.IsNullOrEmpty(queryDict["email"]);
            bool hasPassword = queryDict.ContainsKey("password") && !string.IsNullOrEmpty(queryDict["password"]);

            if (hasEmail && hasPassword)
            {
                email = queryDict["email"][0];
                password = queryDict["password"][0];
            }

            if (!hasEmail)
            {
                messagesErrorsFields.Add($"{defaultMissingFieldString} \'email\'");
            }

            if (!hasPassword)
            {
                messagesErrorsFields.Add($"{defaultMissingFieldString} \'password\'");
            }

            if (messagesErrorsFields.Count > 0)
            {
                context.Response.StatusCode = 400;
                for (int i = 0; i < messagesErrorsFields.Count; i++)
                {
                    await context.Response.WriteAsync($"{messagesErrorsFields[i]}\n");
                }
            }
            else if (email == "admin@example.com" && password == "admin1234")
            {
                await _next(context);
            }
            else
            {
                await context.Response.WriteAsync($"Invalid login");
            }

        }
    }

    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
