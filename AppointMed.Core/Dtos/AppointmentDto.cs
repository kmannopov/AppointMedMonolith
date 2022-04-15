using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Dtos;

public record AppointmentDto
{
    public Guid DoctorId { get; init; }
    public Guid PatientId { get; init; }
    public DateTime DateTime { get; init; }
    public string Notes { get; set; }
}
