using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) => {
    int firstNumber = 0;
    int secondNumber = 1;
    string? operation = null;
    long? result = null;
    bool missingFirstNumber = !context.Request.Query.ContainsKey("firstNumber");
    bool missingSecondNumber = !context.Request.Query.ContainsKey("secondNumber");
    bool missingOperation = !context.Request.Query.ContainsKey("operation");
    string defaultMessageInvalidInput = "Invalid input for";
    List<string> messagesMissingFields = new List<string>();

    string? firstNumberStr = null;
    string? secondNumberStr = null; ;

    if (!missingFirstNumber)
    {
        firstNumberStr = context.Request.Query["firstNumber"][0];
    }

    if (!missingSecondNumber)
    {
        secondNumberStr = context.Request.Query["secondNumber"][0];
    }

    if (!missingOperation)
    {
        operation = context.Request.Query["operation"][0];
    }

    if (!string.IsNullOrEmpty(firstNumberStr) && !string.IsNullOrEmpty(secondNumberStr))
    {
        bool isFirstNumAllDigits = firstNumberStr.All(char.IsDigit);
        bool isSecondNumAllDigits = secondNumberStr.All(char.IsDigit);

        if (!isFirstNumAllDigits)
        {
            messagesMissingFields.Add($"{defaultMessageInvalidInput} \'firstNumber\'\n");
        }

        if (!isSecondNumAllDigits)
        {
            messagesMissingFields.Add($"{defaultMessageInvalidInput} \'secondNumber\'\n");
        }

        if(isFirstNumAllDigits && isSecondNumAllDigits)
        {
            firstNumber = Int32.Parse(firstNumberStr);
            secondNumber = Int32.Parse(secondNumberStr);
        }
    }

    switch (operation)
    {
        case "+":
        case "add":
            result = firstNumber + secondNumber;
            break;
        case "*":
        case "multiply":
            result = firstNumber * secondNumber;
            break;
        case "/":
        case "division":
            result = firstNumber / secondNumber;
            break;
        case "%":
        case "remain":
            result = firstNumber % secondNumber;
            break;
        case null:
        default:
            messagesMissingFields.Add($"{defaultMessageInvalidInput} \'operation\'\n");
            break;
    }

    if (missingFirstNumber)
    {
        messagesMissingFields.Add($"{defaultMessageInvalidInput} \'firstNumber\'\n");
    }

    if (missingSecondNumber)
    {
        messagesMissingFields.Add($"{defaultMessageInvalidInput} \'secondNumber\'\n");
    }

    if (messagesMissingFields.Count > 0)
    {
        context.Response.StatusCode = 400;
        context.Response.ContentType = "text/plain; charset=utf-8";

        for (int i=0; i<messagesMissingFields.Count; i++)
        {
            await context.Response.WriteAsync(messagesMissingFields[i]);
        }
    } else
    {
        await context.Response.WriteAsync($"{result}");
    }


});

app.Run();
