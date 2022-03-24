using System.ComponentModel.DataAnnotations;

namespace AppointMed.Core.Entities;

public abstract record BaseEntity
{
    [Key]
    public Guid Id { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
