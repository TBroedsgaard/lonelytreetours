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

namespace LonelyTreeTimeLimits
{
    /// <summary>
    /// Interaction logic for NewSaleWindow.xaml
    /// </summary>
    public partial class NewSaleWindow : Window
    {
        public NewSaleWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerDialog customerDialog = new NewCustomerDialog();
            customerDialog.Show();
        }
    }
}
