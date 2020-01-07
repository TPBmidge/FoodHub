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

namespace FoodHub.View.RegistrierungsFenster
{
  /// <summary>
  /// Interaction logic for RegistrierungZusteller.xaml
  /// </summary>
  public partial class RegistrierungZusteller : Window
  {
    public RegistrierungZusteller()
    {
      InitializeComponent();
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left)
        this.DragMove();
    }

    private void Shutdown_Button_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
