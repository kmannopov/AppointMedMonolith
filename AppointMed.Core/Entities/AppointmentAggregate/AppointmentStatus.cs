using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public enum AppointmentStatus
{
    Scheduled,
    CheckedIn,
    Complete,
    Cancelled
}
