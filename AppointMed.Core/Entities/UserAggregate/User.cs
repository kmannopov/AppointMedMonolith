using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.UserAggregate;

public record User : BaseEntity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public UserGender Gender { get; init; }

    public enum UserGender
    {
        Male,
        Female
    }
}
