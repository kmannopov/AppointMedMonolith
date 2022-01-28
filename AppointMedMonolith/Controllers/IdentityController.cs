using AppointMed.API.Contracts.V1;
using AppointMed.API.Contracts.V1.Requests;
using AppointMed.API.Contracts.V1.Responses;
using AppointMed.API.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Tweetbook.Controllers.V1;

public class IdentityController : Controller
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost(ApiRoutes.Identity.Register)]
    public async Task<IActionResult> Register([FromBody]UserRegistrationRequest request)
    {
        var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

        if (!authResponse.Success)
            return BadRequest(new AuthFailedResponse
            {
                Errors = authResponse.Errors
            });

        return Ok(new AuthSuccessResponse
        {
            Token = authResponse.Token
        });
    }

//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0ZXN0QHRlc3QuY29tIiwianRpIjoiNTM3NjdhODEtNDJjOC00OWFmLTllYjMtMTUyNTA0MjJmYTBkIiwiZW1haWwiOiJ0ZXN0QHRlc3QuY29tIiwiaWQiOiI3NDBmOWVjMi01ZjVjLTRlYjEtOGE2OC1iOWZjNTNjODE3NzYiLCJuYmYiOjE2NDMzNzMwNzMsImV4cCI6MTY0MzM4MDI3MywiaWF0IjoxNjQzMzczMDczfQ.SzJ5LXyZtptwLjYkTH4_unv7AeNdEMF-UJM4KUBV2YQ
}
