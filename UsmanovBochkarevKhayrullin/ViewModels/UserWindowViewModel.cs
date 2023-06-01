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
        private ObservableCollection<Book> _carts;
        public ObservableCollection<Book> Cart
        {
            get => _carts;
            set => this.RaiseAndSetIfChanged(ref _carts, value);
        }
        public Book SelectedBook { get;set; } 
        public void AddToCart()
        {
            if (SelectedBook.Amount <= 0)
            {
                SelectedBook.Amount = 0;
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
  .GetMessageBoxStandardWindow("Нет в наличии", "Товара нет в наличии");
                messageBoxStandardWindow.Show();
                return; 
            }
            SelectedBook.Amount -= 1;
            Cart.Add(SelectedBook);
            
        }
        LibraryContext libraryContext;
        public void Buy()
        {
            Cart = new ObservableCollection<Book>();
            libraryContext.SaveChanges();
            var old = Books;
            Books = null;
            Books = old;
        }
        public User user { get; set; }

        public UserWindowViewModel()
        {
            libraryContext = new LibraryContext();
            libraryContext.Users.Load();
            libraryContext.Books.Load();
            Books = libraryContext.Books.Local.ToObservableCollection();
            Cart = new ObservableCollection<Book>();
        }
        public UserWindowViewModel(User user) : this()
        {
            this.user = user;
        }
        
    }
}
