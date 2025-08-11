using System.Text;
using System.Text.Json;
namespace zelis.UI.Services;
public class ApiHttpClient : IApiHttpClient
{
    private readonly HttpClient _http;

    public ApiHttpClient(HttpClient http) => _http = http;

    public Task<HttpResponseMessage> GetAsync(string endpoint) => _http.GetAsync(endpoint);

    public async Task<T?> GetJsonAsync<T>(string endpoint)
    {
        var resp = await _http.GetAsync(endpoint);
        if (!resp.IsSuccessStatusCode) return default;
        var json = await resp.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<T?> PostJsonAsync<T>(string endpoint, object data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        var resp = await _http.PostAsync(endpoint, content);
        if (!resp.IsSuccessStatusCode) return default;
        var json = await resp.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<T?> PutJsonAsync<T>(string endpoint, object data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        var resp = await _http.PutAsync(endpoint, content);
        if (!resp.IsSuccessStatusCode) return default;
        var json = await resp.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public Task<HttpResponseMessage> DeleteAsync(string endpoint) => _http.DeleteAsync(endpoint);
}
