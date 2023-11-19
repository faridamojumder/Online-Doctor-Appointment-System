namespace DoctorAppointmentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        public int PatientID { get; set; }

        [StringLength(50)]
        public string PatientName { get; set; }

        public DateTime? ScheduleDate { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(500)]
        public string Report { get; set; }

        public int? SerialNo { get; set; }

        public int? DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
