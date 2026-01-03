using IDP.Core.ApplicationService.Users.DTOs;
using IDP.Core.ApplicationService.Users.Interfaces;
using IDP.Core.Domain.Users.Entities;
using IDP.EndPoints.WebAPI.Common.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDP.EndPoints.WebAPI.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/user/register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _userService.Register(request);
        return ActionResult(result);  
    }
}
