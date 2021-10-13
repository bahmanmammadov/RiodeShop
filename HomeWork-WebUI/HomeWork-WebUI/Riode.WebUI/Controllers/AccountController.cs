using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Riodetask.AppCode.Extension;
using Riodetask.Migrations;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using Riodetask.Model.FormModel;
using Riodetask.Model.Memberships;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Riodetask.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly RioDbContext db;
        readonly UserManager<RiodeUser> userManager;
        readonly SignInManager<RiodeUser> signinManeger;
        readonly IConfiguration configuraton;
        public AccountController(RioDbContext db, UserManager<RiodeUser> userManager,
            SignInManager<RiodeUser> signinManeger,
            IConfiguration configuraton)
        {
            this.db = db;
            this.userManager = userManager;
            this.signinManeger = signinManeger;
            this.configuraton = configuraton;
        }


        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                //ModelState.Clear();
                //ViewBag.message = "Yerine yetirildi";
                return Json(new
                {
                    error = false,
                    message = "Yerine yetirildi"
                });
            }
            return Json(new
            {
                error = true,
                message = "Yeniden sinayin"
            });


        }





        public IActionResult Profil()
        {
            return View();
        }
        public async Task<IActionResult> logout()
        {
            await signinManeger.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult signin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signin(LoginFormModel user)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (ModelState.IsValid)
            {

                RiodeUser foundedUser = null;
                if (user.UserName.IsEmail())
                {
                    foundedUser = await userManager.FindByEmailAsync(user.UserName);
                }
                else
                {
                    foundedUser = await userManager.FindByNameAsync(user.UserName);
                }
                if (foundedUser == null)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }
                //User rolu olmayani Riodeye buraxmir!!
                //if (!await userManager.IsInRoleAsync(foundedUser, "User"))
                //{
                //    ViewBag.Message("Ad ve ya sifre sehvdir");
                //    return View(user);
                //}


                var sResult = await signinManeger.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (sResult.Succeeded != true)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }
                return RedirectToAction("index", "Home");

                //eger loginnen evvel hansisa sehifede imiwse loginnen sora ora atmag ucun

                var redirectUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (ModelState.IsValid)
            {

                var user = new RiodeUser();
                user.FullName = model.FullName;
                user.UserName = model.UserName;
                //user.EmailConfirmed = true; // tesdiq yazmwiwam
                user.Email = model.Email;


                string token = $"subscribetoken-{model.UserName}-{DateTime.Now:yyyyMMddHHmmss} ";
                string hashtoken = token.Encrypt("BAHMAN");
                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={hashtoken}";

                var mailSent = configuraton.SendEmail(user.Email, "Riode", $"Please confirm your Email through this <a href={path}>link</a>");

                var result = await userManager.CreateAsync(user , model.Password);
                if (result.Succeeded)
                { 
                    ViewBag.Message = "Qeyde Alindi";
                    return RedirectToAction(nameof(signin));
                }
                 foreach (var error in result.Errors)
                 {
                    ModelState.AddModelError(error.Code,error.Description);
                 }
            }
                return View(model);

        }
        [HttpGet]
        [Route("Subscribe-Confirmm")]
        public IActionResult SubscribeConfirm(string token)
        {
            string plaintext = token.Decrypt("BAHMAN");//BAHMAN-key
            Match match = Regex.Match(plaintext, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");
            if (match.Success)
            {
                string id = match.Groups["id"].Value;
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subscribe = db.Users.FirstOrDefault(s => s.UserName == id);
                if (subscribe == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Tokende xeta");
                    goto end;
                }
                if (subscribe.EmailConfirmed == true)
                {
                    ViewBag.Message = Tuple.Create(true, "Artiq Tesdiq Edilib!");
                    goto end;
                }
                userManager.ConfirmEmailAsync(subscribe, token);
                subscribe.EmailConfirmed = true;
                db.SaveChanges();
                ViewBag.Message = Tuple.Create(false, "Abuneliyiniz Tesdiq Edilib!");
            }
        end:
            return View();
        }
    }


}
