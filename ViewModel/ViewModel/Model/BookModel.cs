using FoodHub.Logic.BaseTypes;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FoodHub.Logic.Model
{
  public class BookModel : BaseModel
  {
    protected override void InitCommands()
    {
      base.InitCommands();
      OkCommand = new RelayCommand(
          () =>
          {
            Trace.WriteLine("OK");
          },
          () => IsOk);
    }
    protected override void OnErrorsCollected()
    {
      base.OnErrorsCollected();
      OkCommand.RaiseCanExecuteChanged();
    }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Title must not be empty.")]
    public string Title { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Category must not be empty.")]
    public string Category { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Genre must not be empty.")]
    public string Genre { get; set; }
    public string AgeRestriction { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Author must not be empty.")]
    public string Author { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Publisher must not be empty.")]
    public string Publisher { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }

    public RelayCommand OkCommand { get; private set; }
  }
}
