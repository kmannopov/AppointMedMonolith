using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class Patient
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string PassportNumber { get; set; }
        public int Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }


    }
}
