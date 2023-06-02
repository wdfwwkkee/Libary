using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanovBochkarevKhayrullin.Models;
using UsmanovBochkarevKhayrullin.Views;

namespace UsmanovBochkarevKhayrullin.ViewModels
{
    public class EditAdminWindowViewModel : ViewModelBase
    {
        public EditAdminWindowViewModel() 
        {

        }
        private EditAdminWindow owner;
        public Book book { get; set; } = new Book();
        public EditAdminWindowViewModel(EditAdminWindow owner)
        {
            this.owner = owner;
        }
        public EditAdminWindowViewModel(EditAdminWindow owner, Book book) : this(owner) 
        {
            this.book = book;

        }
        public void Okey()
        {
            if (book.Id < 0)
            {
                (owner.DataContext as AdminWindowViewModel)!.Books.Add(book);
            }
            owner.Close();
            
        }
    }
}
