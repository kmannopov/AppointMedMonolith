using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointMed.Core.Entities.UserAggregate;

public record User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UserGender Gender { get; set; }
    [ForeignKey(nameof(IdentityUser))]
    public string UserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public DateTimeOffset DateRegistered { get; set; }

    public enum UserGender
    {
        Female,
        Male
    }
}
