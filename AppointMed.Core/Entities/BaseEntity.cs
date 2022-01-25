using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Entities;

public abstract record BaseEntity
{
    [Key]
    public Guid Id { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
