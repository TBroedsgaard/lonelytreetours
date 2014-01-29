using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model.Controllers
{
    internal class BookingController : ModelController<IBooking>
    {
        private List<Booking> bookings;

        public BookingController(List<IBooking> iBookings)
        {
            bookings = new List<Booking>();

            foreach (IBooking iBooking in iBookings)
            {
                Booking booking = new Booking(iBooking);
                bookings.Add(booking);
            }
        }

        public override IBooking Create()
        {
            Booking booking = new Booking();
            booking.Deleted = true;
            bookings.Add(booking);

            return (IBooking)booking;
        }

        public IBooking Create(ISale sale)
        {
            Booking booking = new Booking(sale);
            booking.Deleted = true;
            bookings.Add(booking);

            return (IBooking)booking;
        }

        public override IBooking Update(IBooking iBooking)
        {
            Booking oldBooking = findBooking(iBooking.Id);
            if (oldBooking == null)
            {
                return null;
            }

            Booking updatedBooking = new Booking(iBooking);
            bookings.Remove(oldBooking);
            bookings.Add(updatedBooking);

            return (IBooking)updatedBooking;
        }

        public override List<IBooking> GetAll()
        {
            List<IBooking> iBookings = bookings.Cast<IBooking>().ToList();
            return iBookings;
        }

        private Booking findBooking(int? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (Booking booking in bookings)
            {
                if (booking.Id == id)
                { 
                    return booking;
                }
            }

            return null;
        }
    }
}
