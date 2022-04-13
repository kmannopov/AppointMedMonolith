using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointMed.Core.Entities.UserAggregate;

public record User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Key]
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public IdentityUser IdentityUser { get; set; }
    public DateTimeOffset DateRegistered { get; set; }
}
