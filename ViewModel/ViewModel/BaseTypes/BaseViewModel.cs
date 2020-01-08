using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Logic.BaseTypes
{
  public abstract class BaseViewModel : ViewModelBase
  {

    public BaseViewModel()
    {
      if (!IsInDesignModeStatic && !IsInDesignMode)
      {
        DispatcherHelper.Initialize();
      }
    }

    public bool ValidationOk { get; set; } = true;

    public string WindowTitle { get; protected set; }

  }
}

