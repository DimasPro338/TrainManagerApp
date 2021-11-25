
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.ISeatRepository;
using TrainManagerApp.Models;


namespace TrainManagerApp.Repositories
{
    //implement interface
    public class SeatRepository : ISeatRepository<Seat>
    {
        private readonly DataBaseContext context;

        public SeatRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public void CreateRange(List<Seat> seats)
        {
            this.context.Seats.AddRange(seats);
        }
    }
}
