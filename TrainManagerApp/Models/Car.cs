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
            //SetSeats(train, typeOfCar, this);
        }

      /*  private void SetSeats(Train train, TypeOfCar typeOfCar, Car car)
        {
            switch (train.TypeOfTrain)
            {
                case TypeOfTrain.Intercity:
                    switch (typeOfCar)
                    {
                        case TypeOfCar.Class1:
                            Seats = Enumerable.Range(0, 56)
                                   .Select(i => new Seat(train, typeOfCar, false, car))
                                   .ToList();
                            break;
                        case TypeOfCar.Class2:
                            Seats = Enumerable.Range(0, 81)
                                 .Select(i => new Seat(train, typeOfCar, false, car))
                                 .ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case TypeOfTrain.IntercityPlus:
                    break;
                case TypeOfTrain.UsualTrain:
                    switch (typeOfCar)
                    {
                        case TypeOfCar.Luxury:
                            Seats = Enumerable.Range(0, 18)
                                    .Select(i => new Seat(train, typeOfCar, false, car))
                                    .ToList();
                            break;
                        case TypeOfCar.Compartment:
                            Seats = Enumerable.Range(0, 35)
                                    .Select(i => new Seat(train, typeOfCar, false, car))
                                    .ToList();
                            break;
                        case TypeOfCar.Plazcart:
                            Seats = Enumerable.Range(0, 37)
                                    .Select(i => new Seat(train, typeOfCar, false, car))
                                    .ToList();
                            unitOfWork.Seats.CreateRange(Seats);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }*/
        /* public Car(TypeOfCar typeOfUTCar, int dif)
         {
                 switch (typeOfUTCar)
                 {
                     case TypeOfCar.Luxury:
                         seats = Enumerable.Range(0, 18)
                                 .Select(i => new Seat(){ TypeOfUTCar = TypeOfUTCar, TypeOfTrain = TypeOfTrain, Booked = false})
                                 .ToList();
                         break;
                     case TypeOfCar.Compartment:
                         seats = Enumerable.Range(0, 35)
                                 .Select(i => new Seat { TypeOfUTCar = TypeOfUTCar, TypeOfTrain = TypeOfTrain, Booked = false })
                                 .ToList();
                         break;
                     case TypeOfCar.Plazcart:
                         seats = Enumerable.Range(0, 37)
                                 .Select(i => new Seat { TypeOfUTCar = TypeOfUTCar, TypeOfTrain = TypeOfTrain, Booked = false })
                                 .ToList();
                         break;
                     default:
                         break;
                 }
         } 
         public Car(TypeOfIntercity typeOfIntercity)
         {           
                 switch (typeOfIntercity)
                 {
                     case TypeOfIntercity.Class1:
                         seats = Enumerable.Range(0, 56)
                                .Select(i => new Seat { TypeOfIntercity = TypeOfIntercity, TypeOfTrain = TypeOfTrain, Booked = false })
                                .ToList();
                         break;
                     case TypeOfIntercity.Class2:
                         seats = Enumerable.Range(0, 81)
                              .Select(i => new Seat { TypeOfIntercity = TypeOfIntercity, TypeOfTrain = TypeOfTrain, Booked = false })
                              .ToList();
                         break;
                     default:
                         break;
                 }           
         }
        */
    }
}
