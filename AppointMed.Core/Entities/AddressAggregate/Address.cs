using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.AddressAggregate;

public record Address : BaseEntity
{
    public string Region { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string Street { get; init; }
}
