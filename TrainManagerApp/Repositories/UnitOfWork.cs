using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.Interfaces;
using TrainManagerApp.ISeatRepository;
using TrainManagerApp.Models;

namespace TrainManagerApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBaseContext db;

        public UnitOfWork()
        {

        }

        private SeatRepository seatRepository;

        public ISeatRepository<Seat> Seats
        {
            get 
            {
                if (seatRepository == null)
                    seatRepository = new SeatRepository(db);
                return seatRepository;
            }
        }

    }
}
