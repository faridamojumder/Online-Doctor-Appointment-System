using DoctorAppointmentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointmentSystem.ViewModels
{
    public class VmPatient
    {
        public int PatientID { get; set; }
        [Required(ErrorMessage ="Cannot blank Name")]
        [StringLength(50)]
        public string PatientName { get; set; }
        [Required]
        public DateTime? ScheduleDate { get; set; }

        [StringLength(50)]
        [Required]
        public string Gender { get; set; }

        [StringLength(500)]
        public string Report { get; set; }
        [Required(ErrorMessage = "SerialNo Required")]
        [MinLength(2,ErrorMessage = "SerialNo Should be 2 digit")]
        public int SerialNo { get; set; }

        public int DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}