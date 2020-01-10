using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace FoodHub.Logic.BaseTypes
{
  public abstract class BaseModel : INotifyPropertyChanged, IDataErrorInfo
  {

    private static List<PropertyInfo> _propertyInfos;


    public event PropertyChangedEventHandler PropertyChanged;


    public BaseModel()
    {
      InitCommands();
    }


    public string Error => string.Empty;

    public string this[string columnName]
    {
      get
      {
        CollectErrors();
        return Errors.ContainsKey(columnName) ? Errors[columnName] : string.Empty;
      }
    }

    protected virtual void InitCommands()
    {
    }


    protected virtual void OnErrorsCollected()
    {
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void CollectErrors()
    {
      Errors.Clear();
      PropertyInfos.ForEach(
          prop =>
          {
            var currentValue = prop.GetValue(this);
            var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
            var minAttr = prop.GetCustomAttribute<MinLengthAttribute>();
            var maxLenAttr = prop.GetCustomAttribute<MaxLengthAttribute>();
            var emailAttr = prop.GetCustomAttribute<EmailAddressAttribute>();
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
            if (minAttr != null)
            {
              if ((currentValue?.ToString() ?? string.Empty).Length < minAttr.Length)
              {
                Errors.Add(prop.Name, minAttr.ErrorMessage);
              }
            }
            if (emailAttr != null)
            {
              if (emailAttr.Equals("Test"))//TODO Fehler beheben
              {
                Errors.Add(prop.Name, emailAttr.ErrorMessage);
              }
            }
            // further attributes
          });
      // we have to this because the Dictionary does not implement INotifyPropertyChanged            
      OnPropertyChanged(nameof(HasErrors));
      OnPropertyChanged(nameof(IsOk));
      // commands do not recognize property changes automatically
      OnErrorsCollected();
    }

    
    public bool HasErrors => Errors.Any();


    public bool IsOk => !HasErrors;


    protected List<PropertyInfo> PropertyInfos
    {
      get
      {
        return _propertyInfos
               ?? (_propertyInfos =
                   GetType()
                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(prop => prop.IsDefined(typeof(RequiredAttribute), true) || prop.IsDefined(typeof(MaxLengthAttribute), true) || prop.IsDefined(typeof(MinLengthAttribute), true) || prop.IsDefined(typeof(EmailAddressAttribute), true))
                       .ToList());
      }
    }
    string test = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

    private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
  }
}

