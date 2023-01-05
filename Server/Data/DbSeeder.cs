using Microsoft.EntityFrameworkCore;

namespace OttokeBlazor.Server.Data
{
    public class DbSeeder
    {
        public static void Seed(WebApplication app)
        {
            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
