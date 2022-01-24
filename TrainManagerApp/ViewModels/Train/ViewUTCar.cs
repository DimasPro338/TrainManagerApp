using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainManagerApp.Models;

namespace TrainManagerApp.ViewModels.Train
{
    public class ViewUTCar
    {
        [Required]
        [Display (Name = "Type of car")]
        public TypeOfCar TypeOfCar { get; set; }

        [Required]
        [Display(Name = "Number of carts")]
        public int CartsNum { get; set; }
        public TypeOfTrain TypeOfTrain { get; set; }
        public int TrainId { get; set; }

    }
}
