using Microsoft.EntityFrameworkCore;
using ToDoApp.Repository;

namespace ToDoApp
{
    public partial class App : Application
    {
        //public static ToDoDbContext ToDoDbContext { get; private set; }
     
        //public static UserRepository UserRepository { get; private set; }


        public App()
        {
            InitializeComponent();

            //string? connectionString = "Server=localhost,1433;Database=ToDoAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";

            //var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
            //optionsBuilder.UseSqlServer(connectionString);

            //ToDoDbContext = new ToDoDbContext(optionsBuilder.Options);

            //UserRepository = new UserRepository(ToDoDbContext);

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}