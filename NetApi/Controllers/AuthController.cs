using AutoMapper;
using Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;    
    public AuthController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    [HttpGet]
    public IActionResult VerifyAuth()
    {
        return Ok();
    }
    [HttpPost]
    [Route("login")]    
    public IActionResult Login()
    {
        return Ok();
    }
    [HttpPost]
    [Route("register")]    
    public IActionResult Register()
    {
        return Ok();
    }
}