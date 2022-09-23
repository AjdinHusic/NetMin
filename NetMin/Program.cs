using Microsoft.AspNetCore.Cors.Infrastructure;
using NetMin.Extensions;
using NetMin.Interfaces;
using NetMin.Repositories;
using NetMin.Services;
using static DotNetEnv.Env;

var builder = WebApplication.CreateBuilder(args);

Load();
var connectionString = GetString("DB_CONNECTION");
builder.Services.AddSingleton<IDbConnectionFactory, MySqlConnectionFactory>();
builder.Services.ConfigureSqlKata(connectionString);
builder.Services.AddScoped<ICoreDbRepository, CoreDbRepository>();
builder.Services.AddControllers();
builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(new CorsPolicy()
    {
        Origins = { "*" },
        Methods = { "*" },
        Headers = { "*" }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.MapControllers();

app.Run();