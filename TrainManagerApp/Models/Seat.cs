using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainManagerApp.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Booked { get; set; }
        public TypeOfCar TypeOfCar { get; set; }
        public TypeOfTrain TypeOfTrain { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }

        public Seat()
        {

        }
        public Seat(Train train, TypeOfCar typeOfCar, bool booked, Car car)
        {
            Car = car;
            Car.Id = car.Id;
            Booked = booked;
            TypeOfCar = typeOfCar;
            TypeOfTrain = train.TypeOfTrain;
            SetPrice(train, typeOfCar);
        }

        private void SetPrice(Train train, TypeOfCar typeOfCar)
        {
                switch (train.TypeOfTrain)
                {
                    case TypeOfTrain.Intercity:
                        switch (typeOfCar)
                        {
                            case TypeOfCar.Class1:
                                Price = 500;
                                break;
                            case TypeOfCar.Class2:
                                Price = 300;
                                break;
                            default:
                                break;
                        }
                        break;
                    case TypeOfTrain.IntercityPlus:
                        switch (TypeOfCar)
                        {
                            case TypeOfCar.Class1:
                                Price = 400;
                                break;
                            case TypeOfCar.Class2:
                                Price = 200;
                                break;
                            default:
                                break;
                        }
                        break;
                    case TypeOfTrain.UsualTrain:
                        switch (TypeOfCar)
                        {
                            case TypeOfCar.Luxury:
                                Price = 1500;
                                break;
                            case TypeOfCar.Compartment:
                                Price = 500;
                                break;
                            case TypeOfCar.Plazcart:
                                Price = 120;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
        }

    }
}
