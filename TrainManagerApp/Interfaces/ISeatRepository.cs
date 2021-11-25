using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainManagerApp.ISeatRepository
{
    public interface ISeatRepository<T> where T : class
    {
        void CreateRange(List<T> items);
    }
    
}
