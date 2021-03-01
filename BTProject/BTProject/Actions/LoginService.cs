using BTProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace BTProject.Actions
{
    public class LoginService : ILoginService
    {
        private readonly DataContext con;

        public LoginService (DataContext context)
        {
            con = context;
        }

        public ContentResult Login(SignInUser model)
        {
            var mail = con.SignInUser.SingleOrDefault(x => x.Email.Equals(model.Email));
            var pass = con.SignInUser.SingleOrDefault(x => x.Email.Equals(model.Email) & x.Password.Equals(model.Password));

            if (mail == null)
            {
                var res = new ContentResult
                {
                    Content = "NoUser",
                    StatusCode = 0

                };
                return res;
            }
            else if(pass == null)
            {
                var res = new ContentResult
                {
                    Content = "NoPass",
                    StatusCode = 1
                };
                return res;
            }
            else
            {
                var res = new ContentResult
                {
                    Content = pass.Id.ToString(),
                    StatusCode = 2
                };
                return res;
            }
     
        }

        public async Task<ContentResult> SignIn(SignInUser model)
        {
            var add = await con.AddAsync(model);
            var res = await con.SaveChangesAsync();
            if (res == 1)
                return new ContentResult
                {
                    StatusCode = 2
                };
            else
                return new ContentResult
                {
                    StatusCode = 1
                };

        }
    }
}
