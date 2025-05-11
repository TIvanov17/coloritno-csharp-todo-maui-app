using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoApp.Pages;
using ToDoApp.Repository;
using ToDoApp.Service;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<ToDoDbContext>(options =>
                   options.UseSqlServer("Server=localhost,1433;Database=ToDoAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"));

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            
            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();

            try
            {
                if (dbContext.Database.CanConnect())
                {
                    Console.WriteLine("✅ Connected to the database successfully.");
                }
                else
                {
                    Console.WriteLine("❌ Failed to connect to the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error connecting to database: {ex.Message}");
            }

            dbContext.Database.EnsureCreated();
            return app;
        }
    }
}
