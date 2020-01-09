using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace FoodHub.Logic
{
  public class ViewModelLocator
  {
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
      if (ViewModelBase.IsInDesignModeStatic)
      {
        // Create design time view services and models                
      }
      else
      {
        // Create run time view services and models                
      }
      SimpleIoc.Default.Register<MainViewModel>();
      SimpleIoc.Default.Register<RegistrierungCustomerViewModel>();
    }

    public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
    public RegistrierungCustomerViewModel Zusteller => ServiceLocator.Current.GetInstance<RegistrierungCustomerViewModel>();

    public static void Cleanup()
    {
    }
  }
}