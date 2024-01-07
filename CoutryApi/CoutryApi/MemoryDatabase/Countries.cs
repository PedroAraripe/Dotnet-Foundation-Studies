namespace CoutryApi.MemoryDatabase
{
    public class CountriesDatabase
    {
        public static Dictionary<int, string> countries = new Dictionary<int, string>()
        {
            {
                1, "United States"
            },
            {
                2, "Canada"
            },
            {
                3, "United Kingdom"
            },
            {
                4, "India"
            },
            {
                5, "Japan"
            },
        };

        public static Dictionary<int, string> GetCountries()
        {
            return countries;

        }

        public static string? GetCountry(int id)
        {
            if (!countries.ContainsKey(id))
            {
                return null;
            }

            return countries[id];
        }
        public static int GetCountriesTotal()
        {
            return countries.Keys.Count;
        }
    }
}
