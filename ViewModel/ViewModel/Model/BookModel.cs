using FoodHub.Logic.BaseTypes;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public string Title { get; set; }
    public string Category { get; set; }
    public string Genre { get; set; }
    public string SelfRegulation { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }

    public RelayCommand OkCommand { get; private set; }
  }
}
