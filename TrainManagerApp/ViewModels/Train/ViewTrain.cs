using System;
using System.ComponentModel.DataAnnotations;
using TrainManagerApp.Models;

namespace TrainManagerApp.ViewModels.Train
{
    public class ViewTrain
    {
        [Required]
        [Display(Name = "Type of train")]
        public TypeOfTrain TypeOfTrain { get; set; }
        [Required]
        [Display(Name = "Point of departure")]
        public Route PointOfDeparture { get; set; }
        [Required]
        [Display(Name = "Point of arrival")]
        public Route PointOfArrival { get; set; }

        [Required]
        [Display(Name = "Date of departure")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfDeparture { get; set; }
        
        [Required]
        [Display(Name = "Date of arrival")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfArrival { get; set; }
        public TypeOfCar TypeOfCar { get; set; }
    }
}
