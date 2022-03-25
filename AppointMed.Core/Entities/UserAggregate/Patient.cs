using AppointMed.Core.Entities.AddressAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.UserAggregate;

public record Patient : User
{
    [ForeignKey(nameof(Address))]
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
