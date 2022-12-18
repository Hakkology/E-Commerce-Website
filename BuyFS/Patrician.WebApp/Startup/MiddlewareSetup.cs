using MerchantFS.DataAccessLayer.SeedData;

namespace Patrician.WebApp.Startup
{
    public static class MiddlewareSetup
    {
        public static WebApplication MiddleWareConfigurations(this WebApplication app)
        {

            //Seed is used only once to add data for testing.
            //Seed.Seed1();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.MapDefaultControllerRoute();
            });

            //app.MapRazorPages();
            return app;
        }
    }
}
