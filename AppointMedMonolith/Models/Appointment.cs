using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Clinic { get; set; }
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public int Status { get; set; }

    }
}
