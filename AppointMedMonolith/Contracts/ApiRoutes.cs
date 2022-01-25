namespace AppointMed.API.Contracts;

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
    }

    public static class Appointments
    {
        public const string GetAll = $"{Base}/appointments";
        public const string Get = $"{Base}/appointments/{{appointmentId}}";
        public const string Create = $"{Base}/appointments";
        public const string Update = $"{Base}/appointments/{{appointmentId}}";
        public const string Delete = $"{Base}/appointments/{{appointmentId}}";
    }
}
