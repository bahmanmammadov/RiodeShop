using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        readonly RioDbContext db;
        public BlogController(RioDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {

            var data = db.BlogPosts
                .Where(b=>b.PublishDate != null && b.DeleteByUserId == null)
                .ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {

            var data = db.BlogPosts

                .FirstOrDefault(b => b.ID == id);
                //.ToList();
            return View(data);
        }
    }
}
