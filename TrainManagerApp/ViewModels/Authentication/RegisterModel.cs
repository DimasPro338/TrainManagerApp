using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainManagerApp.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Email not specified")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]        
        [Compare("Password", ErrorMessage = "Password not specified in the right way")]
        public string ConfirmPassword { get; set; }
    }
}
