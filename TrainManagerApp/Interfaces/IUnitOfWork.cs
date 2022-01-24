using TrainManagerApp.ISeatRepository;
using TrainManagerApp.Models;

namespace TrainManagerApp.Interfaces
{
    public interface IUnitOfWork
    {
        ISeatRepository<Seat> Seats { get; }
    }
}
