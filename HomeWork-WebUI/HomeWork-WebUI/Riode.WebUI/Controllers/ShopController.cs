using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.DataContexts;
using Riodetask.Model.ViewModels;
using System.Linq;

namespace Riode.WebUI.Controllers
{
    public class ShopController : Controller
    {
        readonly RioDbContext db;
        public ShopController(RioDbContext db)
        {
            this.db = db;
        }

        // index
        public IActionResult Index()
        {
            ShopFilterViewModel vm = new ShopFilterViewModel();


            vm.brands = db.Brands
                .Where(b => b.DeleteByUserId == null)
                .ToList();

            vm.productSizes = db.Sizes
                 .Where(b => b.DeleteByUserId == null)
                 .ToList();

            vm.productColors = db.ProductColors
                 .Where(b => b.DeleteByUserId == null)
                 .ToList();

            vm.OneCategories = db.Categories
                .Include(c => c.Parent)                                // children chilren getiri yeni incude include 
                .Include(c => c.Children)                              // her bir category children apar
                .ThenInclude(c => c.Children)                          // children chilren getiri yeni incude include 
                .ThenInclude(c => c.Children)
                .Where(c => c.ParentID == null && c.DeleteByUserId == null)
                .ToList();

            vm.Products = db.Product
                .Include(p => p.Images.Where(i => i.isMain == true))
                .Include(c => c.Brand)
                .Where(c => c.DeleteByUserId == null)
                .ToList();




            return View(vm);
        }
        // etrafli
        public IActionResult Details(int id)
        {

            var product = db.Product
                .Include(i => i.Images)
                .Include(i => i.Brand)
                .FirstOrDefault(p => p.ID == id && p.DeleteByUserId == null);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        //[HttpPost]
        //public IActionResult Filter([FromBody] ShopFilterFormModel model)
        //{
        //    return Json(new
        //    {

        //        error = false,
        //        data = model
        //    });
        //}
    }
}