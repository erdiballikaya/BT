using BTProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTProject.Actions
{
    public interface ILoginService
    {
        ContentResult Login(SignInUser model);

        Task<ContentResult> SignIn(SignInUser model);
    }
}
