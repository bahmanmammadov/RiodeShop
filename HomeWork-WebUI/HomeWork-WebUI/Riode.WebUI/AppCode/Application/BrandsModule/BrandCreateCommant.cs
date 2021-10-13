using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Riodetask.AppCode.Extension;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.BrandsModule
{
    public class BrandCreateCommant : IRequest<Brand>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public class BrandCreateCommantHandler : IRequestHandler<BrandCreateCommant, Brand>
        {
            private readonly RioDbContext db;
            private readonly IActionContextAccessor ctx;


            public BrandCreateCommantHandler(RioDbContext db, IActionContextAccessor ctx)
            {
                this.ctx = ctx;
                this.db = db;
            }
            public async Task<Brand> Handle(BrandCreateCommant request, CancellationToken cancellationToken)
            {
                if (ctx.IsModelStateValid())
                {
                    Brand brand = new Brand();
                    brand.Name = request.Name;
                    brand.Description = request.Description;
                    db.Brands.Add(brand);
                    await db.SaveChangesAsync(cancellationToken);
                    return brand;
                }
                return null;
                
            }
        }
    }
}
