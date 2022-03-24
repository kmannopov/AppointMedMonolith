using AppointMed.Core.Entities.AddressAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppointMed.Core.Entities.ClinicAggregate;

public record Clinic : BaseEntity
{
    public string Name { get; set; }
    public IEnumerable<Department> Departments { get; init; }
    public Address Address { get; init; }
}
