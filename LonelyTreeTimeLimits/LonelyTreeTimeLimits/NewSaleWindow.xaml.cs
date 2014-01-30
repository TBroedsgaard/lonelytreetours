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
using Model;
using Interfaces;
namespace LonelyTreeTimeLimits
{
    /// <summary>
    /// Interaction logic for NewSaleWindow.xaml
    /// </summary>
    public partial class NewSaleWindow : Window
    {
        ModelFacade modelFacade;
        ISale sale;
        public NewSaleWindow(ModelFacade modelFacade)
        {
            InitializeComponent();
            this.modelFacade = modelFacade;

            sale = this.modelFacade.CreateSale();
            sale.CreatedDate = DateTime.Now;

            sale = this.modelFacade.UpdateSale(sale);

            DateLabel.Content = sale.CreatedDate;

            CustomerCombo.ItemsSource = modelFacade.GetCustomers();
            customerTypeCombo.ItemsSource = getCustomerTypes();

            StatusCombo.ItemsSource = getSaleStatusTypes();

            BookingsListbox.ItemsSource = modelFacade.GetBookings(sale);
        }

        public NewSaleWindow(ModelFacade modelFacade, ISale sale)
        {
            InitializeComponent();
            this.modelFacade = modelFacade;
            this.sale = sale;

            DateLabel.Content = this.sale.CreatedDate.ToShortDateString();

            if (this.sale.SpecialRequests != null)
                specialRequestTextbox.Text = this.sale.SpecialRequests;

            CustomerCombo.ItemsSource = modelFacade.GetCustomers();
            customerTypeCombo.ItemsSource = getCustomerTypes();

            if (this.sale.Customer != null)
                CustomerCombo.SelectedItem = this.sale.Customer; // Virker ikke

            StatusCombo.ItemsSource = getSaleStatusTypes();

            BookingsListbox.ItemsSource = modelFacade.GetBookings(sale);
        }

        private List<string> getCustomerTypes()
        {
            return Enum.GetNames(typeof(CustomerType)).ToList();
        }

        private List<string> getSaleStatusTypes()
        { 
            return Enum.GetNames(typeof(SaleStatus)).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerDialog customerDialog = new NewCustomerDialog(modelFacade);
            customerDialog.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BookingsWindow bk = new BookingsWindow(modelFacade, sale);
            bk.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void saveSaleButton_Click(object sender, RoutedEventArgs e)
        {
            sale.Customer = (ICustomer)CustomerCombo.SelectedItem;
            sale.SaleStatus = (SaleStatus)Enum.Parse(typeof(SaleStatus), StatusCombo.SelectedItem.ToString()); //StatusCombo.SelectedItem
            sale.SpecialRequests = specialRequestTextbox.Text;

            modelFacade.UpdateSale(sale);

            Close();
        }

        private void editBookingButton_Click(object sender, RoutedEventArgs e)
        {
            IBooking booking = (IBooking)BookingsListbox.SelectedItem;
            BookingsWindow bk = new BookingsWindow(modelFacade, booking);

            bk.Show();
        }
    }
}
