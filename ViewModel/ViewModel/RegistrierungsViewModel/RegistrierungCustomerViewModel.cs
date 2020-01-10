using FoodHub.Logic.BaseTypes;
using FoodHub.Logic.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Logic
{
  public class RegistrierungCustomerViewModel : BaseViewModel
  {
    public RegistrierungCustomerViewModel()
    {
      if (IsInDesignMode)
      {

      }
      else
      {

      }
    }

    public CustomerModel customerModel { get; set; } = new CustomerModel();
  }
}
