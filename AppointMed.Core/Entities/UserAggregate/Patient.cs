using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.UserAggregate;

public record Patient : User
{
    public Address Address { get; set; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}
