using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Application.FaqsModule;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;

namespace Riodetask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqsController : Controller
    {
        private readonly RioDbContext db;
        private readonly IMediator mediator;


        public FaqsController(RioDbContext db , IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        // GET: Admin/Faqs
        public async Task<IActionResult> Index()
        {
            return View(await db.Faqs.Where(m=>m.DeleteByUserId == null).ToListAsync());
        }

        // GET: Admin/Faqs/Details/5
        public async Task<IActionResult> Details(FaqsSingleQuery query)
        {

            var  faq = await mediator.Send(query);
            return View(faq);
        }

        // GET: Admin/Faqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FaqsCreateCommand response)
        {
            var faq =  await mediator.Send(response);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(faq);
        }

        // GET: Admin/Faqs/Edit/5
        public async Task<IActionResult> Edit(FaqsSingleQuery query)
        {

            Faq faq = await mediator.Send(query);

            if (faq == null)
            {
                return NotFound();
            }
            FaqsViewModel vm = new FaqsViewModel();
            vm.Answer = faq.Answer;
            vm.Question = faq.Question;
            vm.Id = faq.ID;
            return View(vm);
            
        }

        // POST: Admin/Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FaqsEditCommand response)
        {
            var faq = await mediator.Send(response);
            if (faq>0)
            {
                return RedirectToAction(nameof(Index));
            };
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(FaqsRemoveCommand request)
        {
            var response = await mediator.Send(request);
            return Json(response);
        }

        
    }
}
