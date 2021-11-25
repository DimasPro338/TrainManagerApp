using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainManagerApp.Models
{
    public enum TypeOfCar
    {
        Luxury,
        Compartment,
        Plazcart,
        [Display(Name = "Class 1")]
        Class1,
        [Display(Name = "Class 2")]
        Class2
    }
}
