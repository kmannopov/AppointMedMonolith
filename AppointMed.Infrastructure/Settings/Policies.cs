﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Infrastructure.Settings;

public static class Policies
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
    }
}
