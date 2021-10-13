using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Mail_box()
        {
            return View();
        }
        public IActionResult Layout()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult inVoice()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
    }
}
