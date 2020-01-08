using FoodHub.Logic.BaseTypes;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Logic.Model
{
  public class ZustellerModel : BaseModel
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

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name must not be empty.")]
    public string Lastname { get; set; }

    [MinLength(5, ErrorMessage = "Bitte minimum 5 Zeichen eingeben")]
    public string Password { get; set; }

    public RelayCommand OkCommand { get; private set; }
  }
}
