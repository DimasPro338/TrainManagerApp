using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.Repositories;

namespace TrainManagerApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public TypeOfTrain TypeOfTrain { get; set; }       
        public TypeOfCar TypeOfCar { get; set; }
        public int TrainId  { get; set; }
        public Train Train  { get; set; }
        public List<Seat> Seats { get; set; }

        public Car()
        {

        }
        public Car(Train train, TypeOfCar typeOfCar)
        {
            Train = train;
            TrainId = train.Id;
            TypeOfTrain = train.TypeOfTrain;
            TypeOfCar = typeOfCar;
        }    
    }
}
