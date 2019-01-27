using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Columbo.IdentityProvider.Sts.ViewModels;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Columbo.IdentityProvider.Sts.Controllers
{
    public class AccountController : Controller
    {
        private readonly TestUserStore _users;
        private readonly IIdentityServerInteractionService _interaction;

        public AccountController(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authContext = _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
                //todo validate credential

                AuthenticationProperties props = null;
                //subjectid, username, props
                await HttpContext.SignInAsync("1", "admin", props);

                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Login", new { returnUrl = model.ReturnUrl });
        }
    }
}