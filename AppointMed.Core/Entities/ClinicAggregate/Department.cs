using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities.ClinicAggregate;

public record Department : BaseEntity
{
    public string Name { get; set; }
}
