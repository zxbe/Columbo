using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Columbo.IdentityProvider.Sts.Services;
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
        private readonly IUserIdentityService _userIdentityService;
        private readonly IIdentityServerInteractionService _interaction;

        public AccountController(IUserIdentityService userIdentityService, IIdentityServerInteractionService interaction)
        {
            _userIdentityService = userIdentityService;
            _interaction = interaction;
        }

        public IActionResult Login(string returnUrl)
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
                if (!_interaction.IsValidReturnUrl(model.ReturnUrl))
                {
                    return RedirectToAction("Login"); //todo notification
                }

                var userIdentityId = _userIdentityService.VerifyUserIdentity(model.Login, model.Password);
                if (!userIdentityId.HasValue)
                {
                    return RedirectToAction("Login"); //todo notification
                }
                
                AuthenticationProperties props = null;
                await HttpContext.SignInAsync(userIdentityId.ToString(), model.Login, props);

                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Login", new { returnUrl = model.ReturnUrl });
        }
    }
}