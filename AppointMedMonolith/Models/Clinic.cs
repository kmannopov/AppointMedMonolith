using System;
using System.Collections.Generic;

namespace AppointMed.API.Models
{
    public partial class Clinic
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Address { get; set; }
        public int PhoneNumber { get; set; }
        public byte[]? Image { get; set; }

    }
}
