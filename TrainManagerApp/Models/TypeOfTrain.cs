using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainManagerApp.Models
{
    public enum TypeOfTrain
    {
        Intercity,
        [Display(Name = "Intercity+")]
        IntercityPlus,
        [Display(Name = "Train")]
        UsualTrain
    }
}
