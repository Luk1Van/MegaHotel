using MegaHotel.Models.UserModels;
using MegaHotel.Services.IHotelServices;
using MegaHotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MegaHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)//ModelState stores all models user sends. Thats is controller 
            {
                User user = _userService.CheckUser(loginModel.Email, loginModel.Password).FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user);
                    if(user._userRole.Role == "admin")
                    {
                        return RedirectToAction("NewRoom", "Admin");
                    }
                    return RedirectToAction("List", "Room");
                }
                ModelState.AddModelError("", "Incorrect email or password");
            }
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if(ModelState.IsValid)
            {
                User user = _userService.CheckUserEmail(registerModel.Email).FirstOrDefault();
                if (user == null)
                {
                    var newUser = await _userService.AddUser(registerModel.Email, registerModel.Password);
                    User userRole = _userService.CheckUser(newUser.Email, newUser.Password).FirstOrDefault();
                    await Authenticate(userRole);

                    return RedirectToAction("List", "Room");
                }
                else
                    ModelState.AddModelError("", "This email is already used");
            }
            return View(registerModel);
        }
        
        private async Task Authenticate(User user)
        {
            // Creates Claim object
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user._userRole?.Role)
            };
            // Creates object ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // Installing authenticational cookies
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}
