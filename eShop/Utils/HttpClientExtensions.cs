using System.Text.Json;

namespace eShop.Utils
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContextAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw
                    new ApplicationException($"Something went wrong calling the API: " +
                    $"{response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });

        }
    }
}
