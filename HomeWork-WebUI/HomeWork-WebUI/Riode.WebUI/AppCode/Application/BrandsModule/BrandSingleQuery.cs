using MediatR;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.BrandsModule
{
    public class BrandSingleQuery : IRequest<Brand>
    {
        public int Id { get; set; }
        
        public class BrandSingleQueryHandler : IRequestHandler<BrandSingleQuery, Brand>
        {
            private readonly RioDbContext db;

            public BrandSingleQueryHandler(RioDbContext db)
            {
                this.db = db;
            }

            public async Task<Brand> Handle(BrandSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id== null || request.Id <0)
                {
                    return null;

                }
                var brand = await db.Brands.FirstOrDefaultAsync(m => m.ID == request.Id ,cancellationToken);
                return brand;

            }
        }
    }
}
