using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainManagerApp.Models
{
    public class Train
    {
        public int Id { get; set; }
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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfArrival { get; set; }
        public List<Car> Carts { get; set; } = new List<Car>();
    }
}
