using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
  public class RegistrierungZustellerViewModel : BaseViewModel
  {
    public RegistrierungZustellerViewModel()
    {
      OkCommand = new RelayCommand(
                () =>
                {
                  Trace.WriteLine("OK");
                },
                () => IsOk);

    }

    protected override void OnErrorsCollected()
    {
      OkCommand.RaiseCanExecuteChanged();
    }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name must not be empty.")]
    public string Lastname { get; set; }

    [MinLength(5, ErrorMessage = "Bitte minimum 5 Zeichen eingeben")]
    public string Password { get; set; }

    public RelayCommand OkCommand { get; }
  }
}
