namespace AppointMed.API.Contracts.V1;

public static class ApiRoutes
{
    public const string Root = "api";
    public const string Version = "v1";
    public const string Base = $"{Root}/{Version}";

    public static class Clinics
    {
        public const string GetAll = $"{Base}/clinics";
        public const string Get = $"{Base}/clinics/{{clinicId}}";
        public const string Create = $"{Base}/clinics";
        public const string Update = $"{Base}/clinics/{{clinicId}}";
        public const string Delete = $"{Base}/clinics/{{clinicId}}";
        public const string GetByDept = $"{Base}/clinics/dept/{{deptName}}";
    }

    public static class Patients
    {
        public const string Get = $"{Base}/patients/{{patientId}}";
        public const string Create = $"{Base}/patients";
        public const string Update = $"{Base}/patients";
    }

    public static class Doctors
    {
        public const string Get = $"{Base}/doctors/{{doctorId}}";
        public const string Create = $"{Base}/doctors";
        public const string Update = $"{Base}/doctors";
        public const string UpdateWorkplace = $"{Base}/doctors/{{doctorId}}";
        public const string GetByDept = $"{Base}/doctors/dept/{{deptId}}";
    }

    public static class Appointments
    {
        public const string GetAllForPatient = $"{Base}/appointments/patient/{{userId}}";
        public const string GetAllForDoctor = $"{Base}/appointments/doctor/{{userId}}";
        public const string GetSlots = $"{Base}/appointments/times/{{doctorId}}";
        public const string Get = $"{Base}/appointments/{{appointmentId}}";
        public const string Create = $"{Base}/appointments";
        public const string Update = $"{Base}/appointments/{{appointmentId}}";
    }
    public static class Identity
    {
        public const string Login = $"{Base}/identity/login";
        public const string Register = $"{Base}/identity/register";
        public const string Refresh = $"{Base}/identity/refresh";
    }
}
