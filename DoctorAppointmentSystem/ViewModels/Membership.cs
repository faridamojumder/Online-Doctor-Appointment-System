using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.ViewModels
{
    public class Membership
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName Connot Blank")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Connot Blank")]
        public string Password { get; set; }
    }
}