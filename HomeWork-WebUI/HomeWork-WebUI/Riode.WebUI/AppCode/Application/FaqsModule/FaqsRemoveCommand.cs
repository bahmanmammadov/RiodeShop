using MediatR;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Infastructure;
using Riodetask.Model.DataContexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.FaqsModule
{
    public class FaqsRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int? Id { get; set; }

        public class FaqsRemoveCommandHandler : IRequestHandler<FaqsRemoveCommand, CommandJsonResponse>
        {
            private readonly RioDbContext db;

            public FaqsRemoveCommandHandler(RioDbContext db)
            {
                this.db = db;
            }

            public async Task<CommandJsonResponse> Handle(FaqsRemoveCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();
                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Sehvlik var";
                    goto end;

                }
                var faqs = await db.Faqs.FirstOrDefaultAsync(m => m.ID == request.Id && m.DeleteByUserId == null);
                if (faqs == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyil";
                    goto end;
                }
                faqs.DeleteByUserId = 1;
                faqs.DeletedTime = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "Ugurlu Emeliyyat";

            end:
                return response;

            }

            
        }
    }
}
