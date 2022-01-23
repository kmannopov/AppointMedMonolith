using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.UserAggregate;

public record Doctor : User
{
    public Clinic Clinic { get; init; }
    public List<Appointment> Schedule { get; set; }

}
