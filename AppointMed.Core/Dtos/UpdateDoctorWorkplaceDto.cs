using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Dtos;

public record UpdateDoctorWorkplaceDto
{
    public Guid ClinicId { get; set; }
    public Guid DepartmentId { get; set; }
}
