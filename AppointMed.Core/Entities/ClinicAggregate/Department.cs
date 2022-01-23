using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public record Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
