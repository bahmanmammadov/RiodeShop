using MediatR;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.FaqsModule
{
    public class FaqsSingleQuery : IRequest<Faq>
    {
        public int Id { get; set; }
        public class FaqsSingleQueryHandler : IRequestHandler<FaqsSingleQuery, Faq>
        {
            readonly RioDbContext db;
            public FaqsSingleQueryHandler(RioDbContext db)
            {
                this.db = db;
            }
            public async Task<Faq> Handle(FaqsSingleQuery request, CancellationToken cancellationToken)
            {

                var faq = await db.Faqs.FirstOrDefaultAsync(m => m.ID == request.Id , cancellationToken);

                if (faq==null)
                {
                    return null;
                }

                return faq;
            }
        }
    }
}
