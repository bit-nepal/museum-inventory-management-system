using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mims.Authorization.Constants;
using mims.DTOs;
using mims.Services.Interfaces;
using mims.Views.Admin.Account;
using mims.Views.Admin.Artifact;

namespace mims.Controllers;

[Authorize(Policy = ApplicationPolicy.Administrators)]
[Route("Admin/Account")]
public class AccountController : Controller
{
  private readonly ILogger<AccountController> _logger;
  private const string rootViewDirectory = "/Views/Admin/Account/";
  private readonly ILoginService<ApplicationUserLoginDTO> _loginService;
  public AccountController(ILogger<AccountController> logger, ILoginService<ApplicationUserLoginDTO> loginService)
  {
    _logger = logger;
    _loginService = loginService;
  }


  [AllowAnonymous]
  [Route("Login")]
  public IActionResult Index()
  {
    return View(rootViewDirectory + "Login.cshtml");
  }

  [AllowAnonymous]
  [HttpPost]
  public async Task<IActionResult> Login(ApplicationUserLoginDTO user)
  {
    // Validate model, authenticate user, etc.
    Console.WriteLine("Attempting Login");
    var result = await _loginService.SignInAsync(user);

    if (result.Succeeded)
    {
      return RedirectToAction("Index", "Admin");
    }
    else
    {
      // Handle failed login
      ModelState.AddModelError(string.Empty, "Invalid login attempt.");
      return View(rootViewDirectory + "Login.cshtml");
    }
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [Route("Profile")]
  public IActionResult Profile()
  {
    return View(rootViewDirectory + "Profile.cshtml");
  }

    [Authorize(Policy = ApplicationPolicy.Administrators)]
    [Route("Username")]
    public IActionResult Username()
    {
        return View(rootViewDirectory + "Username.cshtml");
    }


  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [Route("Password")]
  public IActionResult Password()
  {
    return View(rootViewDirectory + "Password.cshtml");
  }
}
