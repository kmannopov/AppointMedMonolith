using AppointMed.Core.Entities.ClinicAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.UserAggregate;

public record Doctor : User
{
    public Guid ClinicId { get; init; }
    public Department Department { get; init; }

}
