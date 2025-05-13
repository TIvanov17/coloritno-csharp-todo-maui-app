using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Model
{
    public class Tasks : INotifyPropertyChanged
    {

        [Key]
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
