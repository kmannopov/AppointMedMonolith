using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public class Location
{
    [Key]
    public Guid Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
