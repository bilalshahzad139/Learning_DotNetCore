using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore_Demos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace ASPNETCore_Demos.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View(new LoginDTO());
        }
        
        [HttpPost]
        public IActionResult Login2()
        {
            string log = Request.Form["login"];
            string password = Request.Form["password"];

            return View("Login");
        }

        [HttpPost]
        public IActionResult Login3(string login,string password)
        {
            return View("Login");
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login4(LoginDTO dto)
        {

            if (UserManager.ValidateUser(dto.Login,dto.Password) == true)
            {
                ViewBag.Msg = "Valid User!";
            }
            else
            {
                ViewBag.Msg = "Invalid User!";
            }
            return View("Login",dto);
        }
    }
}