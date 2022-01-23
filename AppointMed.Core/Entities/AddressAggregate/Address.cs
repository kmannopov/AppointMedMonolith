using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public class Address
{
    public string Region { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string Street { get; init; }
}
