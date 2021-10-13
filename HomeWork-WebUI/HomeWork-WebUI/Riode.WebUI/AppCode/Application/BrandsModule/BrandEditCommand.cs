using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Extension;
using Riodetask.Model.DataContexts;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.BrandsModule
{
    public class BrandEditCommand : BrandViewModel, IRequest<int>
    {
        

        public class BrandEditCommandHandler : IRequestHandler<BrandEditCommand, int>
        {
            private readonly RioDbContext db;
            private readonly IActionContextAccessor ctx;
    
            public BrandEditCommandHandler(RioDbContext db, IActionContextAccessor ctx)
            {
                this.ctx = ctx;
                this.db = db;
            }
            public async Task<int> Handle(BrandEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id == null || request.Id<0)
                {
                    return 0;
                }
                var entity = await db.Brands.FirstOrDefaultAsync(r => r.ID == request.Id && r.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }
                if (ctx.IsModelStateValid())
                {
                    entity.Name = request.Name;
                    entity.Description = request.Description;
                    entity.ID = entity.ID;

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }
                return 0;
            }
        }
    }
}
