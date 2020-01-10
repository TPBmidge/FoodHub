using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FoodHub.View.RegistrierungsFenster;

namespace FoodHub.View.RegistrierungsFenster
{
  /// <summary>
  /// Interaction logic for AuswahlRegistrierungView.xaml
  /// </summary>
  public partial class AuswahlRegistrierungView : Window
  {
    public AuswahlRegistrierungView()
    {
      InitializeComponent();
    }
    private void Shutdown_Button_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left)
        this.DragMove();
    }

    private void Register_food_supplier_Button_Click(object sender, RoutedEventArgs e)
    {
      RegistrierungCustomer registrierungCustomer = new RegistrierungCustomer();
      registrierungCustomer.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      registrierungCustomer.Show();
    }
  }
}
