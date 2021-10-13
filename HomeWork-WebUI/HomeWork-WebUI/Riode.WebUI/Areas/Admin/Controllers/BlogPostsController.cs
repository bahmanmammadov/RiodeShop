using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;

namespace Riodetask.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BlogPostsController : Controller
    {
        readonly RioDbContext db;
        readonly IWebHostEnvironment env;

        public BlogPostsController(RioDbContext db , IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        // GET: Admin/BlogPosts
        public async Task<IActionResult> Index()
        {
            return View(await db.BlogPosts
                .Where(b => b.PublishDate == null && b.DeleteByUserId==null)
                .OrderByDescending(b=>b.ID)
                .ToListAsync());
        }

        // GET: Admin/BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BlogPost blogPost, IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("file", "File secilmeyib");
            }
            if (ModelState.IsValid)
            {

                string extension = Path.GetExtension(file.FileName);
                blogPost.ImagePath = $"{Guid.NewGuid()}{extension}";
                string pyschialFileName = Path.Combine(env.ContentRootPath,
                    "wwwroot",
                    "uploads",
                    "images",
                    "blog",
                     blogPost.ImagePath);
                using (var stream = new FileStream(pyschialFileName,FileMode.Create,FileAccess.Write))
                {
                    await file.CopyToAsync(stream);
                }

                db.Add(blogPost);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPost blogPost, IFormFile file, string fileTemp)
        {
            if (string.IsNullOrEmpty(fileTemp) && file == null)
            {
                ModelState.AddModelError("file", "Shekil secilmeyib");
            }
            
            if (id != blogPost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await db.BlogPosts.FirstOrDefaultAsync(b => b.ID == id && b.DeleteByUserId==null);
                    entity.Title = blogPost.Title;
                    entity.Body = blogPost.Body;
                    if (file !=null)
                    {
                        string extension = Path.GetExtension(file.FileName);
                        blogPost.ImagePath = $"{Guid.NewGuid()}{extension}";
                        string pyschialFileName = Path.Combine(env.ContentRootPath,
                            "wwwroot",
                            "uploads",
                            "images",
                            "blog",
                             blogPost.ImagePath);
                        using (var stream = new FileStream(pyschialFileName, FileMode.Create, FileAccess.Write))
                        {
                            await file.CopyToAsync(stream);
                        }
                        if (!string.IsNullOrWhiteSpace(entity.ImagePath))
                        {
                            System.IO.File.Delete(Path.Combine(env.ContentRootPath, 
                                "wwwroot",
                                "uploads",
                                "images",
                                "blog",
                                entity.ImagePath));
                        }
                        entity.ImagePath = blogPost.ImagePath;
                    }
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await db.BlogPosts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await db.BlogPosts.FindAsync(id);
            db.BlogPosts.Remove(blogPost);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return db.BlogPosts.Any(e => e.ID == id);
        }
    }
}
