using Microsoft.EntityFrameworkCore;
using zelis.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var conn =
    builder.Configuration.GetConnectionString("Sql")
    ?? builder.Configuration["ConnectionStrings__Sql"]
    ?? "Server=localhost,1433;Database=ZelisPaymentsDb;User Id=sa;Password=SqlDocker!2025;TrustServerCertificate=True";

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conn));

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddCors(o =>
    o.AddPolicy("AllowUI", p => p
        .WithOrigins("http://localhost:5001") // add more if needed
        .AllowAnyHeader()
        .AllowAnyMethod()));

var app = builder.Build();

app.UseCors("AllowUI");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();