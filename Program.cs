using Microsoft.AspNetCore.ResponseCompression;
using MultiplayerTicTacToe.Hubs;
using MultiplayerTicTacToe.Models;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzcyNzc5QDMyMzAyZTMzMmUzMEdKa0tjYUNLbU8xY2ZVbFVjeEVONUVEYnlvaHNlQkRUcDNnbCtTNWhVcGs9");
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<MultiplayerHub>("/MultiplayerHub");
app.MapFallbackToPage("/_Host");

app.Run();
