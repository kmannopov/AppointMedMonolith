﻿namespace AppointMed.API.Contracts.V1.Responses;

public class AuthFailedResponse
{
    public IEnumerable<string> Errors { get; set; }
}
