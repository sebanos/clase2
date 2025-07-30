using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TaskFlowPro.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults for .NET Aspire
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add UI State Services
builder.Services.AddScoped<IUIStateService, UIStateService>();

// Add HTTP client for API communication
builder.Services.AddHttpClient("TaskFlowProApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7002/api/");
});

var app = builder.Build();

// Map default endpoints for .NET Aspire
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
