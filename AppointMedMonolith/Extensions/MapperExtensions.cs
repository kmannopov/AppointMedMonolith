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
            Latitude = request.Latitude,
            Longitude = request.Longitude
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
            Latitude = request.Latitude,
            Longitude = request.Longitude
        };
    }

    public static List<Department> MapToDepartmentList(this List<CreateDepartmentDto> departmentDtos)
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

    public static Patient MapToNewPatient(this CreatePatientDto request, HttpContext httpContext)
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
            Email = httpContext.User.Claims.Single(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value,
            DateRegistered = DateTimeOffset.UtcNow
        };
    }

    public static Doctor MapToNewDoctor(this CreateDoctorDto request, HttpContext httpContext)
    {
        return new Doctor()
        {
            UserId = httpContext.GetUserId(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Email = httpContext.User.Claims.Single(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value,
            DateRegistered = DateTimeOffset.UtcNow
        };
    }

    public static Patient MapToExistingPatient(this Patient currentPatient, CreatePatientDto request)
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
            Email = currentPatient.Email,
            DateRegistered = currentPatient.DateRegistered
        };
    }

    public static Doctor MapToExistingDoctor(this Doctor currentDoctor, CreateDoctorDto request)
    {
        return new Doctor()
        {
            UserId = currentDoctor.UserId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            Email = currentDoctor.Email,
            DateRegistered = currentDoctor.DateRegistered
        };
    }

    public static PatientDto MapToPatientDto(this Patient patient)
    {
        return new PatientDto
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            Address = patient.Address.MapToAddressDto(),
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email
        };
    }

    public static DoctorDto MapToDoctorDto(this Doctor doctor)
    {
        return new DoctorDto
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            DateOfBirth = doctor.DateOfBirth,
            Gender = doctor.Gender,
            PhoneNumber = doctor.PhoneNumber,
            Email = doctor.Email,
            ClinicId = doctor.ClinicId,
            DepartmentId = doctor.DepartmentId
        };
    }

    public static AddressDto MapToAddressDto(this Address address)
    {
        return new AddressDto
        {
            Region = address.Region,
            City = address.City,
            District = address.District,
            Street = address.Street,
            Latitude = address.Latitude,
            Longitude = address.Longitude,
        };
    }

    public static List<ClinicDto> MapToClinicDto(this List<Clinic> clinics)
    {
        var clinicDtos = new List<ClinicDto>();

        foreach (var clinic in clinics)
        {
            clinicDtos.Add(new ClinicDto
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Address = clinic.Address.MapToAddressDto(),
                Departments = clinic.Departments.MapToDepartmentDto()
            });
        }

        return clinicDtos;
    }

    public static List<DepartmentDto> MapToDepartmentDto(this List<Department> departments)
    {
        var departmentDtos = new List<DepartmentDto>();
        foreach (var department in departments)
        {
            departmentDtos.Add(new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name
            });
        }

        return departmentDtos;
    }
}
