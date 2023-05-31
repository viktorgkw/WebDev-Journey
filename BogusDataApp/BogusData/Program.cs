using BogusData.Data;
using BogusData.Health;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// HealthChecks
/*
    AspNetCore.HealthChecks has some nuget packages
    that give us ready to use health checks!

    For example we can download the SQL package and write:
    .AddSqlServer(connectionString)
*/
builder.Services.AddHealthChecks()
    .AddCheck<AppHealthCheck>("DatabaseConnection");

// DI
builder.Services.AddTransient<DataGenerator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/_health", new HealthCheckOptions
{
    // UIResponseWriter is external nuget package -> HealthChecks.UI.Client
    // It's very useful for descriptive result!
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
})/*.RequireAuthorization()*/;

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
