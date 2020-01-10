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
  public class CustomerModel : BaseModel
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


    #region CustomerProperties

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name must not be empty.")]
    public string Lastname { get; set; }

    [MinLength(5, ErrorMessage = "Bitte minimum 5 Zeichen eingeben")]
    public string Password { get; set; }

    public DateTime Birthdate { get; set; }

    [EmailAddress(ErrorMessage ="Keine Gültige Email")]
    public string EmailAddress { get; set; }

    public int Phonenumber { get; set; }

    public int Postcode { get; set; }

    public string Location { get; set; }

    public string Street { get; set; }

    public string Housenumber { get; set; }

    public string Username { get; set; }

    public RelayCommand OkCommand { get; private set; }

    #endregion
  }
}
