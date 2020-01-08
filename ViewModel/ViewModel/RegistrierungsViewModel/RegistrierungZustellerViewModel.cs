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
  public class RegistrierungZustellerViewModel : BaseViewModel
  {
    public RegistrierungZustellerViewModel()
    {
      if (IsInDesignMode)
      {

      }
      else
      {

      }
    }

    public ZustellerModel ZustellerModel { get; set; } = new ZustellerModel();
  }
}
