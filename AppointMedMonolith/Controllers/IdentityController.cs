using AppointMed.API.Contracts.V1;
using AppointMed.API.Contracts.V1.Requests;
using AppointMed.API.Contracts.V1.Responses;
using AppointMed.API.Extensions;
using AppointMed.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;

public class IdentityController : Controller
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost(ApiRoutes.Identity.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new AuthFailedResponse
            {
                Errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage))
            });
        var authResponse = await _identityService.RegisterAsync(request.Email, request.Password, request.Role);

        if (!authResponse.Success)
            return BadRequest(new AuthFailedResponse
            {
                Errors = authResponse.Errors
            });

        return Ok(authResponse.MapToAuthSuccessResponse());
    }

    [HttpPost(ApiRoutes.Identity.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

        if (!authResponse.Success)
            return BadRequest(new AuthFailedResponse
            {
                Errors = authResponse.Errors
            });

        return Ok(authResponse.MapToAuthSuccessResponse());
    }

    [HttpPost(ApiRoutes.Identity.Refresh)]
    public async Task<IActionResult> Login([FromBody] RefreshTokenRequest request)
    {
        var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

        if (!authResponse.Success)
            return BadRequest(new AuthFailedResponse
            {
                Errors = authResponse.Errors
            });

        return Ok(authResponse.MapToAuthSuccessResponse());
    }
}
