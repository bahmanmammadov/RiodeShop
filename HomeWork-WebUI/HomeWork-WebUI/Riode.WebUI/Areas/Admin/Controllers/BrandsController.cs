using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Application.BrandsModule;
using Riodetask.AppCode.Infastructure;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly RioDbContext db;
        private readonly IMediator mediator;


        public BrandsController(RioDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index()
        {
            return View(await db.Brands.Where(v=>v.DeleteByUserId==null).ToListAsync());
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            
            
             Brand brand = await mediator.Send(query);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateCommant  command )
        {
            if (ModelState.IsValid)
            {
              await  mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {
            Brand brand = await mediator.Send(query);

            if (brand == null)
            {
                return NotFound();
            }
            BrandViewModel vm = new BrandViewModel();
            vm.Name = brand.Name;
            vm.Description = brand.Description;
            vm.Id = brand.ID;
            return View(vm);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandEditCommand request)
        {

            int id =  await mediator.Send(request);
            if (id>0)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BrandRemoveCommand request)
        {
            
            var response = await mediator.Send(request);

            return Json(response);
        }
    }
}
