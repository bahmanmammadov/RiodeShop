using MediatR;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Infastructure;
using Riodetask.Model.DataContexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.BrandsModule
{
    public class BrandRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int? Id { get; set; }

        public class BrandRemoveCommandHandler : IRequestHandler<BrandRemoveCommand, CommandJsonResponse>
        {
            private readonly RioDbContext db;

            public BrandRemoveCommandHandler(RioDbContext db)
            {
                this.db = db;
            }

            public async Task<CommandJsonResponse> Handle(BrandRemoveCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();
                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Sehvlik var";
                    goto end;

                }
                var brand = await db.Brands.FirstOrDefaultAsync(m => m.ID == request.Id && m.DeleteByUserId == null);
                if (brand == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyil";
                    goto end;
                }
                brand.DeleteByUserId = 1;
                brand.DeletedTime = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "Ugurlu Emeliyyat";

                end:
                return response;

            }


        }
    }
}
