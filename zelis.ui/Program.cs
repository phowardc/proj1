using Zelis.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Razor Components + Server interactivity
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// API HttpClient (fallback for local dev)
var apiBase = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000/";
if (!Uri.TryCreate(apiBase, UriKind.Absolute, out var apiBaseUri))
    throw new InvalidOperationException($"ApiBaseUrl is invalid: '{apiBase}'");

builder.Services.AddHttpClient("api", c => c.BaseAddress = apiBaseUri);
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    // app.UseHttpsRedirection(); // off unless you’ve set up HTTPS locally
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
