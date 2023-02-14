using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RazorClientMVC.Models;
using RazorClientMVC.Services;

namespace RazorClientMVC.Controllers;

[AllowAnonymous]
public class AuthController : Controller
{
    private readonly AuthService Auth;
    private readonly ILogger Logger;
    public AuthController(ILogger logger, AuthService auth)
    {
        Logger = logger;
        Auth = auth;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AuthenticateAsync([FromBody] User user)
    {
        bool isLogged = await Auth.Login(user);
        if (isLogged)
            return View("Home");
        else
            return View(nameof(Login));
    }
}