using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using ClickRabbitERP_Testing.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userservice;
        private readonly ERPDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserService userService, ERPDbContext context)
        {
            _logger = logger;
            _userservice = userService;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("denied")]
        public IActionResult Denied()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secured()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (_userservice.TryValidateUser(username, password, out List<Claim> claim))
            {
                // var claims = new List<Claim>();
                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var items = new Dictionary<string, string>();
                items.Add(".AuthScheme", CookieAuthenticationDefaults.AuthenticationScheme);
                var properties = new AuthenticationProperties(items);
                await HttpContext.SignInAsync(claimsPrincipal, properties);
                return Redirect(returnUrl);
            }
            else
            {
                TempData["error"] = "Invalid password or username!";
                return View("login");
            }

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            
            await HttpContext.SignOutAsync();
            return Redirect("/");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            List<AppUser> appUsers;
            appUsers = _context.AppUser.ToList();
            return View(appUsers);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult UserEntry(int? id)
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Select Role", Value = "0", Selected = true ,Disabled=true});

            items.Add(new SelectListItem { Text = "Admin", Value = "Admin" });

            items.Add(new SelectListItem { Text = "Purchase", Value = "Purchase" });

            items.Add(new SelectListItem { Text = "Sales", Value = "Sales" });


            ViewBag.RoleType = items;

            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                var obj = _context.AppUser.Find(id);
                if (obj is null)
                {
                    return View();

                }
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult UserEntry(AppUser appUser)
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            if (appUser.UserId == 0)
            {
                _context.Add(appUser);
            }
            else
            {
                _context.Update(appUser);

            }
            _context.SaveChanges();
            return RedirectToAction("Users");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var obj = _context.AppUser.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.AppUser.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }
      
    }
}
