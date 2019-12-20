using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
    public partial class ViewModel
    {
        static string cn_String = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\buerger\Source\Repos\TPBmidge\FoodHub\View\ViewCore\dbFoodHub.mdf;Integrated Security = True";
        public static void Worker()
        {

            SqlConnection cn = new SqlConnection(cn_String);

        }
    }
}
