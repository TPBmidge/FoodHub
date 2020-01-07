using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
  public abstract class BaseViewModel : ViewModelBase, IDataErrorInfo
  {
    private static List<PropertyInfo> _propertyInfos;

    public string Error => string.Empty;

    public string this[string columnName]
    {
      get
      {
        CollectErrors();
        return Errors.ContainsKey(columnName) ? Errors[columnName] : string.Empty;
      }
    }

    protected abstract void OnErrorsCollected();

    private void CollectErrors()
    {
      Errors.Clear();
      PropertyInfos.ForEach(
          prop =>
          {
            var currentValue = prop.GetValue(this);
            var minLenAttr = prop.GetCustomAttribute<MinLengthAttribute>();
            var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
            var maxLenAttr = prop.GetCustomAttribute<MaxLengthAttribute>();
            if (requiredAttr != null)
            {
              if (string.IsNullOrEmpty(currentValue?.ToString() ?? string.Empty))
              {
                Errors.Add(prop.Name, requiredAttr.ErrorMessage);
              }
            }
            if (maxLenAttr != null)
            {
              if ((currentValue?.ToString() ?? string.Empty).Length > maxLenAttr.Length)
              {
                Errors.Add(prop.Name, maxLenAttr.ErrorMessage);
              }
            }
            if (minLenAttr != null)
            {
              if ((currentValue?.ToString() ?? string.Empty).Length < minLenAttr.Length)
              {
                Errors.Add(prop.Name, minLenAttr.ErrorMessage);
              }
            }
            // further attributes
          });
      // we have to this because the Dictionary does not implement INotifyPropertyChanged            
      RaisePropertyChanged(() => HasErrors);
      RaisePropertyChanged(() => IsOk);
      // commands do not recognize property changes automatically
      OnErrorsCollected();
    }

    public bool HasErrors => Errors.Any();

    public bool IsOk => !HasErrors;

    protected List<PropertyInfo> PropertyInfos
    {
      get
      {
        if (_propertyInfos == null)
        {
          // TODO filter for other attributes
          _propertyInfos =
              GetType()
                  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  .Where(prop => prop.IsDefined(typeof(RequiredAttribute), true) || prop.IsDefined(typeof(MaxLengthAttribute), true) || prop.IsDefined(typeof(MinLengthAttribute), true))
                  .ToList();
        }
        return _propertyInfos;
      }
    }

    private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
  }
}

