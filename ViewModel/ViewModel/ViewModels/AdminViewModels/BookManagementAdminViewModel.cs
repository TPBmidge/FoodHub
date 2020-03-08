using FoodHub.Logic.BaseTypes;
using FoodHub.Logic.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FoodHub.Logic.ViewModels.AdminViewModels
{
  public class BookManagementAdminViewModel : BaseViewModel
  {
    public BookManagementAdminViewModel()
    {

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
              AgeRestriction = Guid.NewGuid().ToString("N").Substring(0, 10),
              Category = Guid.NewGuid().ToString("N").Substring(0, 10),
              Rating = 4
            });
      }
      Books = new ObservableCollection<BookModel>(bookList);

      BooksView = CollectionViewSource.GetDefaultView(Books) as ListCollectionView;
      BooksView.CurrentChanged += (s, e) =>
      {
        RaisePropertyChanged(() => BookModel);
      };

      BooksView.SortDescriptions.Clear();
      BooksView.SortDescriptions.Add(new SortDescription(nameof(BookModel.Title), ListSortDirection.Ascending));

      AddBookCommand = new RelayCommand(() =>
      {
        var newBook = new BookModel();
        Books.Add(newBook);
        BookModel = newBook;
      }, BookModel.IsOk);

      SaveBookCommand = new RelayCommand(() => Trace.WriteLine("OK"), BookModel.IsOk
        );

    }
    public RelayCommand AddBookCommand { get; }
    public RelayCommand SaveBookCommand { get; }
    public ICollectionView BooksView { get; }
    private ObservableCollection<BookModel> Books { get; set; }
    public BookModel BookModel
    {
      get => BooksView.CurrentItem as BookModel;
      set
      {
        BooksView.MoveCurrentTo(value);
        RaisePropertyChanged();
      }
    }
  }
}
