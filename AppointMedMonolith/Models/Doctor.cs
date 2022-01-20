using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class Doctor
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string PassportNumber { get; set; }
        public int Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Clinic { get; set; }
        public int Department { get; set; }

    }
}
