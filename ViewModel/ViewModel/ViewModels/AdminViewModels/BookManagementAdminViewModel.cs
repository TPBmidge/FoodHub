using FoodHub.Logic.BaseTypes;
using FoodHub.Logic.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Logic.ViewModels.AdminViewModels
{
  public class BookManagementAdminViewModel : BaseViewModel
  {
    public BookManagementAdminViewModel()
    {
      AddBookCommand = new RelayCommand(() => Books.Add(new BookModel()));
      var bookList = new List<BookModel>();
      for (var i = 0; i < 10; i++)
      {
        bookList.Add(
            new BookModel
            {
              Author = Guid.NewGuid().ToString("N").Substring(0, 10),
              Genre = Guid.NewGuid().ToString("N").Substring(0, 10),
              Publisher = Guid.NewGuid().ToString("N").Substring(0, 10),
              Title = Guid.NewGuid().ToString("N").Substring(0, 10),
              SelfRegulation = Guid.NewGuid().ToString("N").Substring(0, 10),
              Category = Guid.NewGuid().ToString("N").Substring(0, 10)
            });
      }

    Books = new ObservableCollection<BookModel>(bookList);
    }
    public RelayCommand AddBookCommand { get;}
    public ObservableCollection<BookModel> Books { get; set; }
    public BookModel BookModel { get; set; } = new BookModel();
  }
}
