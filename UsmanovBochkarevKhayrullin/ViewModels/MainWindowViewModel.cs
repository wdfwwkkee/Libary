using ReactiveUI;
using System.Linq;
using System.Reactive;
using UsmanovBochkarevKhayrullin.Models;
using UsmanovBochkarevKhayrullin.Views;

namespace UsmanovBochkarevKhayrullin.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);

        }
        public MainWindow Owner { get; set; }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; }

        public MainWindowViewModel(MainWindow _owner)
        {
            Owner = _owner;
            AuthCommand = ReactiveCommand.Create(Auth);
        }
        public MainWindowViewModel()
        {

        }

        public void Auth()
        {
            LibraryContext dbContext = new LibraryContext();
            User? user = dbContext.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();
            if (user == null)
            {
                Message = "Неправильный логин или пароль";
                return;
            }
            switch (user.Role)
            {
                case "admin":
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.DataContext = new AdminWindowViewModel(user);
                    adminWindow.Show();
                    break;
                case "user":
                    UserWindow userWindow = new UserWindow();
                    userWindow.DataContext = new UserWindowViewModel();
                    userWindow.Show();
                    break;
            }
            Owner.Close();
            
        }
    }
}