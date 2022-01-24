using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.Models;
using TrainManagerApp.ViewModels.Train;

namespace TrainManagerApp.Controllers
{
    public class AdminTrainController : Controller
    {
        private readonly DataBaseContext context;
        private static Train trainUn;
        public AdminTrainController(DataBaseContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult> DisplayTrains()
        {
            return View(await context.Trains.ToListAsync());
        }

        public IActionResult AddTrain()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrain(Train train)
        {
            if (ModelState.IsValid)
            {
                trainUn = train;
                return RedirectToAction("AddUTCart");
            }
            return View(train);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AuthorizeUser()
        {
            return RedirectToAction(nameof(DisplayTrains));
        }

        [HttpGet]
        public IActionResult AddUTCart()
        {
            ViewUTCar viewUTCar = new ViewUTCar();
            viewUTCar.TypeOfTrain = trainUn.TypeOfTrain;
            return View(viewUTCar);
        }

        [HttpPost]
        public async Task<IActionResult> AddUTCart(ViewUTCar viewCar)
        {
            if (ModelState.IsValid)
            {
                viewCar.TypeOfTrain = trainUn.TypeOfTrain;
                trainUn.Carts = Enumerable.Range(0, viewCar.CartsNum)
                .Select(i => new Car(trainUn, viewCar.TypeOfCar))
                .ToList();
                context.Add(trainUn);
                await context.SaveChangesAsync();
                SetSeats(trainUn.Carts, trainUn, viewCar.TypeOfCar);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(DisplayTrains));
            }
            return View(viewCar);
        }

        private void SetSeats(List<Car> listOfSeats, Train train, TypeOfCar typeOfCar)
        {
            foreach (var car in listOfSeats)
            {
                switch (train.TypeOfTrain)
                {
                    case TypeOfTrain.Intercity:
                        switch (typeOfCar)
                        {
                            case TypeOfCar.Class1:
                                car.Seats = Enumerable.Range(0, 56)
                                       .Select(i => new Seat(train, typeOfCar, false, car))
                                       .ToList();
                                AddSave(car.Seats);
                                break;
                            case TypeOfCar.Class2:
                                car.Seats = Enumerable.Range(0, 81)
                                     .Select(i => new Seat(train, typeOfCar, false, car))
                                     .ToList();
                                AddSave(car.Seats);
                                break;
                        }
                        break;
                    case TypeOfTrain.IntercityPlus:
                        break;
                    case TypeOfTrain.UsualTrain:
                        switch (typeOfCar)
                        {
                            case TypeOfCar.Luxury:
                                car.Seats = Enumerable.Range(0, 18)
                                        .Select(i => new Seat(train, typeOfCar, false, car))
                                        .ToList();
                                AddSave(car.Seats);
                                break;
                            case TypeOfCar.Compartment:
                                car.Seats = Enumerable.Range(0, 35)
                                        .Select(i => new Seat(train, typeOfCar, false, car))
                                        .ToList();
                                AddSave(car.Seats);
                                break;
                            case TypeOfCar.Plazcart:
                                car.Seats = Enumerable.Range(0, 37)
                                        .Select(i => new Seat(train, typeOfCar, false, car))
                                        .ToList();
                                AddSave(car.Seats);
                                break;
                        }
                        break;
                }
            }

        }
        private void AddSave(List<Seat> seats)
        {
            context.Seats.AddRange(seats);
            context.SaveChanges();
        }
    }
}
