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
    public class AdminWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set => this.RaiseAndSetIfChanged(ref _books, value);
        }

        private User user { get; set; }

        public AdminWindowViewModel()
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.Users.Load();
            libraryContext.Books.Load();
            Books = libraryContext.Books.Local.ToObservableCollection();
        }
        public AdminWindowViewModel(User user): this()
        {
            this.user = user;
        }
    }
}
