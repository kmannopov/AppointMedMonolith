using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointMed.Core.Entities.UserAggregate;

public record User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UserGender Gender { get; set; }
    [Key]
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public IdentityUser IdentityUser { get; set; }
    public DateTimeOffset DateRegistered { get; set; }

    public enum UserGender
    {
        Female,
        Male
    }
}
