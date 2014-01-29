using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Interfaces;

namespace DataAccess.Controllers
{
    internal class BookingController : DataController<BookingEntity>
    {
        private const string FILENAME = "booking.bin";

        public BookingController()
        {
            binaryHelper = new BinaryHelper<BookingEntity>();
            entities = binaryHelper.Load(FILENAME);
            setNextId();
        }

        internal IBooking Create(IBooking ib)
        {
            ib.Id = getNextId();
            ib.LastUpdated = DateTime.Now;
            ib.Deleted = false;
            BookingEntity be = new BookingEntity(ib);
            entities.Add(be);

            try
            {
                binaryHelper.Save(FILENAME, entities);
            }
            catch
            {
                ib.Deleted = true;
                be.Deleted = true;
                throw;
            }


            return ib;
        }

        internal List<IBooking> GetAll()
        {
            return entities.Cast<IBooking>().ToList();
        }

        internal IBooking Update(IBooking ib)
        {
            BookingEntity oldBe = find(ib);
            ib.LastUpdated = DateTime.Now;
            BookingEntity newBe = new BookingEntity(ib);

            entities.Remove(oldBe);
            entities.Add(newBe);

            binaryHelper.Save(FILENAME, entities);

            return (IBooking)newBe;
        }

        internal IBooking Delete(IBooking ib)
        {
            ib.Deleted = true;
            return Update(ib);
        }

        private BookingEntity find(IBooking ib)
        {
            foreach (BookingEntity be in entities)
            {
                if (be.Id == ib.Id)
                {
                    return be;
                }
            }

            return null;
        }
    }
}