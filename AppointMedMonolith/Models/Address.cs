using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class Address
    {

        public int Id { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

    }
}
