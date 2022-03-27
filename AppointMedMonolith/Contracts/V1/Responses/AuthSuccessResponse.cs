namespace AppointMed.API.Contracts.V1.Responses;

public class AuthSuccessResponse
{
    public string Token { get; init; }
    public string RefreshToken { get; init; }
    public string UserId { get; init; }
}
