using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanovBochkarevKhayrullin.Models;
using UsmanovBochkarevKhayrullin.Views;

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

        public User user { get; set; }

        LibraryContext libraryContext;
        public Book SelectedBook { get; set; }
        
        public AdminWindowViewModel()
        {
            libraryContext = new LibraryContext();
            libraryContext.Users.Load();
            libraryContext.Books.Load();
            Books = libraryContext.Books.Local.ToObservableCollection();
        }
        public AdminWindowViewModel(User user): this()
        {
            this.user = user;
        }
        public void Save()
        {
            libraryContext.SaveChanges();
        }
        public void Update()
        {
            libraryContext = new LibraryContext();
            libraryContext.Books.Load();
            Books = libraryContext.Books.Local.ToObservableCollection();
            var old = Books;
            Books = null;
            Books = old;
        }
        public void Edit()
        {
            EditAdminWindow editAdminWindow = new EditAdminWindow();
            editAdminWindow.DataContext = new EditAdminWindowViewModel(editAdminWindow, SelectedBook);
            editAdminWindow.Show();
        }
    }
}
