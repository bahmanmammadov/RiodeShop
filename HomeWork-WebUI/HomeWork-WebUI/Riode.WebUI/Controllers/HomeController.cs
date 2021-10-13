using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Riodetask.AppCode.Extension;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Riode.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly RioDbContext db;
        readonly IConfiguration configuraton;
        public HomeController(RioDbContext db, IConfiguration configuraton)
        {
            this.db = db;
            this.configuraton = configuraton;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Faq()
        {
            var vm=  db.Faqs.ToList();

            return View(vm);
        }
        [HttpPost]
        public IActionResult Subscribe([Bind("EMail")] Subscribe sbrc)
        {
            if (ModelState.IsValid)
            {
                var data = db.subscribes.FirstOrDefault(z => z.EMail.Equals(sbrc.EMail));
                if (data != null && data.EMailConfirm == true)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Email istifade olunub"
                    });
                }
                else if (data != null && (data.EMailConfirm ?? false == false))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Email istifade olunub"
                    });
                }
                db.subscribes.Add(sbrc);
                db.SaveChanges();
                string token = $"subscribetoken-{sbrc.ID}-{DateTime.Now:yyyyMMddHHmmss} ";
                string hashtoken = token.Encrypt("BAHMAN");
                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={hashtoken}";

                var mailSent = configuraton.SendEmail(sbrc.EMail,"Riode", $"Please confirm your Email through this <a href={path}>link</a>");
                //eger getmese rollback olsun data bazaya uzanmasin!
                if (mailSent == false)
                {
                    db.Database.RollbackTransaction();
                    return Json(new
                    {
                        error = false,
                        message = "Try Again"
                    });
                }


                return Json(new
                {
                    error=false,
                    message="Ugurludur"
                }) ;

            }
            return Json(new
            {
                error = true,
                message = "Ugursuz"
            });
        }
        [HttpGet]
        [Route("Subscribe-Confirm")]
        public IActionResult SubscribeConfirm(string token)
        {
            string plaintext = token.Decrypt("BAHMAN");//BAHMAN-key
           Match match= Regex.Match(plaintext, @"subscribetoken-(?<id>\d+)-(?<executeTimeStamp>\d{14})");
            if (match.Success)
            {
              int id =  Convert.ToInt32(match.Groups["id"].Value);
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subscribe = db.subscribes.FirstOrDefault(s => s.ID == id && s.DeleteByUserId==null);
                if (subscribe == null)
                {
                    ViewBag.message = Tuple.Create(true, "Tokende xeta");
                    goto end;
                }
                if ((subscribe.EMailConfirm ?? false)==true)
                {
                    ViewBag.message =  Tuple.Create(true, "Artiq Tesdiq Edilib!");
                    goto end;
                }
                subscribe.EMailConfirm = true;
                subscribe.EMailConfirmDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.message = Tuple.Create(false, "Abuneliyiniz Tesdiq Edilib!");
            }
            end:
            return View();
        }


    }

}
