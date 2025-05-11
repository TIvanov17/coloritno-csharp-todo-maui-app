using ToDoApp.Model;

namespace ToDoApp.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string idusername);
        Task<List<User>> GetAll();
        Task Save(User user);
        Task<bool> ExistsByUsername(string username);
    }
}
