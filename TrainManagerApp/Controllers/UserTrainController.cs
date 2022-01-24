using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.Models;
using TrainManagerApp.ViewModels.Train;

namespace TrainManagerApp.Controllers
{
    public class UserTrainController : Controller
    {
        private readonly DataBaseContext context;
        private static List<Train> trains;

        public UserTrainController(DataBaseContext context)
        {
            this.context = context;
        }

        public object Trains { get; private set; }

        [HttpGet]
        public IActionResult ChooseTrain()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChooseTrain(ViewTrain train)
        {
            if (ModelState.IsValid)
            {
                trains = context.Trains.Where(x => train.PointOfArrival == x.PointOfArrival
                                               && train.PointOfDeparture == x.PointOfDeparture
                                                && train.DateOfDeparture.Year == x.DateOfDeparture.Year
                                                 && train.DateOfDeparture.Month == x.DateOfDeparture.Month
                                                  && train.DateOfDeparture.Day == x.DateOfDeparture.Day).ToList();
                if (trains != null)
                    return RedirectToAction("DisplayTrains");
                else
                    ModelState.AddModelError("", "Incorrect inputed data");
            }
            return View(train);
        }

        [HttpGet]
        public IActionResult DisplayTrains()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Trains = trains;
            mymodel.Cars = context.Cars.ToList();
            mymodel.Seats = context.Seats.ToList();
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult DisplayTickets(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            List<Car> cars = context.Cars.Where(i => i.TrainId == id).ToList();
            dynamic mymodel = new ExpandoObject();
            List<int> countSeats = new List<int>();
            foreach (Car car in cars)
            {
                countSeats.Add(context.Seats.ToList().Where(it1 => it1.CarId == car.Id).Select(i => i).ToList().Count);
            }
            mymodel.Cars = cars;
            mymodel.Seats = countSeats;
            return View(mymodel);
        }


        public IActionResult DisplaySeats(int? id)
        {
            if (id == null)
            {
               return NotFound();
            }
            List<Seat> seats = context.Seats.Where(i => i.CarId == id).ToList();
            int lefNum = seats.Count % 4;
            int rowNum = (seats.Count - lefNum) / 4;
            dynamic mymodel = new ExpandoObject();
            List<Seat> firstRaw = seats.Take(rowNum).ToList();
            List<Seat> secondRaw = seats.Skip(rowNum).Take(rowNum).ToList();
            List<Seat> thirdRaw = seats.Skip(rowNum * 2).Take(rowNum).ToList();
            List<Seat> fourthRaw = seats.Skip(rowNum * 3).Take(rowNum).ToList();
           
            if (lefNum == 1)
            {
                firstRaw.AddRange(seats.Skip((rowNum * 3) + 1).Take(1).ToList());
            }
            else if(lefNum == 2)
            {
                firstRaw.AddRange(seats.Skip((rowNum * 3) + 1).Take(1).ToList());
                secondRaw.AddRange(seats.Skip((rowNum * 3) + 2).Take(1).ToList());
            }else if(lefNum == 3)
            {
                firstRaw.AddRange(seats.Skip((rowNum * 3) + 1).Take(1).ToList());
                secondRaw.AddRange(seats.Skip((rowNum * 3) + 2).Take(1).ToList());
                thirdRaw.AddRange(seats.Skip((rowNum * 3) + 2).Take(1).ToList());
            }
            mymodel.FirstR = firstRaw;
            mymodel.SecondR = secondRaw;
            mymodel.ThirdR = thirdRaw;
            mymodel.FourthR = fourthRaw;

            return View(mymodel);
        }

        [HttpGet]
        public async Task<IActionResult> OrderTicket(int? id)
        {
            Seat seat =  await context.Seats.FindAsync(id);            
            if (seat != null)
            {
                seat.Booked = true;
                context.Update(seat);
                await context.SaveChangesAsync();
                return View(seat);
            }                   
            return NotFound();
        }

        public IActionResult EndPurchase()
        {
           return View();
        }

        [Authorize(Roles = "user")]
        public IActionResult AuthorizeUser()
        {
            return RedirectToAction(nameof(ChooseTrain));

        }

        private bool SeatExists(int id)
        {
            return context.Seats.Any(e => e.Id == id);
        }
    }
}
