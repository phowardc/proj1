namespace zelis.UI.Services;

public interface IApiHttpClient
{
    Task<HttpResponseMessage> GetAsync(string endpoint);   // let caller handle 404
    Task<T?> GetJsonAsync<T>(string endpoint);
    Task<T?> PostJsonAsync<T>(string endpoint, object data);
    Task<T?> PutJsonAsync<T>(string endpoint, object data);
    Task<HttpResponseMessage> DeleteAsync(string endpoint);
}


