using Patrician.WebApp.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
// Add services to the app.

var app = builder.Build();

app.DevelopmentConfigurations();
app.MiddleWareConfigurations();

app.Run();
