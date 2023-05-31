using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanovBochkarevKhayrullin.Models;

namespace UsmanovBochkarevKhayrullin.ViewModels
{
    public class UserWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set => this.RaiseAndSetIfChanged(ref _books, value);
        }

        public User user { get; set; }

        public UserWindowViewModel()
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Users.Load();
            libraryContext.Books.Load();
            Books = libraryContext.Books.Local.ToObservableCollection();
        }
        public UserWindowViewModel(User user) : this()
        {
            this.user = user;
        }
    }
}
