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
    /// Interaction logic for BookingsWindow.xaml
    /// </summary>
    public partial class BookingsWindow : Window
    {
        ModelFacade modelFacade;
        IBooking booking;

        public BookingsWindow(ModelFacade modelFacade, ISale sale)
        {
            InitializeComponent();

            this.modelFacade = modelFacade;

            booking = modelFacade.CreateBooking(sale);

            bookingTypeComboBox.ItemsSource = getBookingTypes();

            supplierComboBox.ItemsSource = modelFacade.GetSuppliers();
            supplierTypeComboBox.ItemsSource = getSupplierTypes();
        }

        public BookingsWindow(ModelFacade modelFacade, IBooking booking)
        { 
            InitializeComponent();

            this.modelFacade = modelFacade;

            this.booking = booking;

            bookingTypeComboBox.ItemsSource = getBookingTypes();

            supplierComboBox.ItemsSource = modelFacade.GetSuppliers();
            supplierTypeComboBox.ItemsSource = getSupplierTypes();

            if (this.booking.Supplier != null)
            {
                supplierComboBox.SelectedItem = this.booking.Supplier;
            }

            if (booking.StartDate != null)
                startDateDatePicker.SelectedDate = booking.StartDate;
        }

        private List<string> getSupplierTypes()
        {
            return Enum.GetNames(typeof(SupplierType)).ToList();
        }

        private List<string> getBookingTypes()
        {
            return Enum.GetNames(typeof(BookingType)).ToList();
        }

        private void saveBookingButton_Click(object sender, RoutedEventArgs e)
        {
            booking.Supplier = (ISupplier)supplierComboBox.SelectedItem;
            booking.StartDate = (DateTime)startDateDatePicker.SelectedDate;
            booking.EndDate = (DateTime)endDateDatePicker.SelectedDate;
            booking.BookingType = (BookingType)Enum.Parse(typeof(BookingType), bookingTypeComboBox.SelectedItem.ToString());
            booking.TotalAmount = decimal.Parse(totalAmountTextBox.Text);

            booking = modelFacade.UpdateBooking(booking);

            /* The rest is just for show - it needs to be implemented for realz!! */

            IPaymentRuleCatalog prc = modelFacade.GetPaymentRuleCatalog(booking);
            List<IPaymentRule> prs = modelFacade.GetPaymentRules(prc);
            if (prs.Count == 0)
            {
                IPaymentRule pr = modelFacade.CreatePaymentRule(prc);
                pr.ReferenceDate = ReferenceDate.BookingStartDate;
                pr.PaymentDate = -30;
                pr.Percentage = 0.7M;
                pr = modelFacade.UpdatePaymentRule(pr);
                prs.Add(pr);
                IPaymentRule pr2 = modelFacade.CreatePaymentRule(prc);
                pr2.ReferenceDate = ReferenceDate.BookingStartDate;
                pr2.PaymentDate = -60;
                pr2.Percentage = 0.3M;
                pr2 = modelFacade.UpdatePaymentRule(pr2);
                prs.Add(pr2);
            }

            List<IPaymentContract> pcs = modelFacade.CreatePaymentContracts(booking, prs);
            string message = "";
            foreach (IPaymentContract pc in pcs)
            {
                message += pc.DueDate.ToShortDateString() + " " + pc.Amount.ToString() + "\n";
            }

            MessageBox.Show(message);
        }
    }
}
