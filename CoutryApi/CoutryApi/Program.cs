using CoutryApi.MemoryDatabase;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Hello this is a country api, we currently got {CountriesDatabase.GetCountriesTotal()} countries in our database!\nCheck it out at /countries");

app.MapGet("/countries/{CountryId:int:range(1,100)}", async (HttpContext context) =>
{
    int countryId = Convert.ToInt32(context.Request.RouteValues["CountryId"]);

    string? currentCountry = CountriesDatabase.GetCountry(countryId);

    if (currentCountry == null)
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    }
    else
    {
        await context.Response.WriteAsync($"{currentCountry}");
    }
});

app.MapGet("/countries/{CountryId}", async (HttpContext context) =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("The CountryID should be a number between 1 and 100");
});

app.MapGet("/countries", async (HttpContext context) =>
{
    Dictionary<int, string> countries = CountriesDatabase.GetCountries();
    List<int> keyList = new List<int>(countries.Keys);

    for (int i = 0; i < keyList.Count; i++)
    {
        await context.Response.WriteAsync($"{keyList[i]}, {countries[keyList[i]]}");

        if (i != keyList.Count - 1)
        {
            await context.Response.WriteAsync("\n");
        }
    }
});

app.Run();
