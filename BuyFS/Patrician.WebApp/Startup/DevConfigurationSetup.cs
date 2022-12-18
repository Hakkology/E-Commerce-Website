namespace Patrician.WebApp.Startup
{
    public static class DevConfigurationSetup
    {
        public static WebApplication DevelopmentConfigurations(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            return app;
        }
    }
}
