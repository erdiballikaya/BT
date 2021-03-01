using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTProject.Actions;
using BTProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService LoginService;

        public LoginController(ILoginService loginService)
        {
            this.LoginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUser model)
        {
            return Ok(await LoginService.SignIn(model));
        }
        [HttpPost]
        public IActionResult Login(SignInUser model)
        {
            return Ok(LoginService.Login(model));
        }
    }
}
