using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class PhoneNumber
    {

        public int Id { get; set; }
        public string PrimaryNumber { get; set; }
        public string SecondaryNumber { get; set; }

    }
}
