using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
