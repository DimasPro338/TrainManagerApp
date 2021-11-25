using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.ISeatRepository;
using TrainManagerApp.Models;

namespace TrainManagerApp.Interfaces
{
    public interface IUnitOfWork
    {
        ISeatRepository<Seat> Seats { get; }
    }
}
