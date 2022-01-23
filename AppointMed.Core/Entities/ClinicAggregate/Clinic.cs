using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public record Clinic : BaseEntity
{
    public List<Department> Departments { get; init; }
    public Address Address { get; init; }
    public Location Location { get; init; }

}
