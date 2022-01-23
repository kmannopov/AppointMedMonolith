using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public abstract record BaseEntity
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
