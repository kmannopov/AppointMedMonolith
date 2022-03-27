using AppointMed.API.Contracts.V1.Responses;
using AppointMed.Core.Dtos;
using AppointMed.Core.Entities;
using AppointMed.Core.Entities.AuthAggregate;
using AppointMed.Core.Entities.ClinicAggregate;
using AppointMed.Core.Entities.UserAggregate;
using AppointMed.Infrastructure.Extensions;
using NetTopologySuite.Geometries;
using System.IdentityModel.Tokens.Jwt;

namespace AppointMed.API.Extensions;

public static class MapperExtensions
{
    public static AuthSuccessResponse MapToAuthSuccessResponse(this AuthenticationResult authResult)
    {
        return new AuthSuccessResponse
        {
            Token = authResult.Token,
            RefreshToken = authResult.RefreshToken,
            UserId = authResult.UserId
        };
    }

    public static Address MapToNewAddress(this AddressDto request)
    {
        return new Address
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTimeOffset.UtcNow,
            Region = request.Region,
            City = request.City,
            District = request.District,
            Street = request.Street,
            Location = new Point(request.Longitude, request.Latitude) { SRID = 4326 }
        };
    }

    public static Address MapToExistingAddress(this Address currentAddress, AddressDto request)
    {
        return new Address
        {
            Id = currentAddress.Id,
            CreatedDate = currentAddress.CreatedDate,
            Region = request.Region,
            City = request.City,
            District = request.District,
            Street = request.Street,
            Location = new Point(request.Longitude, request.Latitude) { SRID = 4326 }
        };
    }

    public static List<Department> MapToDepartmentList(this List<DepartmentDto> departmentDtos)
    {
        var result = new List<Department>();

        foreach (var dept in departmentDtos)
        {
            if (!string.IsNullOrEmpty(dept.Name))
                result.Add(new Department
                {
                    CreatedDate = DateTimeOffset.UtcNow,
                    Id = Guid.NewGuid(),
                    Name = dept.Name
                });
        }

        return result;
    }

    public static Patient MapToNewPatient(this PatientDto request, HttpContext httpContext)
    {
        return new Patient()
        {
            UserId = httpContext.GetUserId(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = request.Address.MapToNewAddress(),
            PhoneNumber = request.PhoneNumber,
            Email = httpContext.User.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Email).Value,
            DateRegistered = DateTimeOffset.UtcNow
        };
    }

    public static Patient MapToExistingPatient(this Patient currentPatient, PatientDto request)
    {
        return new Patient()
        {
            UserId = currentPatient.UserId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = currentPatient.Address.MapToExistingAddress(request.Address),
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            DateRegistered = currentPatient.DateRegistered
        };
    }

    public static PatientResponse MapToPatientResponse(this Patient patient)
    {
        return new PatientResponse
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email
        };
    }
}
