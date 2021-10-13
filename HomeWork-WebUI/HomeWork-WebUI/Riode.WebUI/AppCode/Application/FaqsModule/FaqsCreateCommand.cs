using MediatR;

using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.FaqsModule
{
    public class FaqsCreateCommand : IRequest<Faq>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public class FaqsCreateCommandHandler : IRequestHandler<FaqsCreateCommand, Faq>
        {
            readonly RioDbContext db;
            public FaqsCreateCommandHandler(RioDbContext db)
            {
                this.db = db;
            }
            public async Task<Faq> Handle(FaqsCreateCommand request, CancellationToken cancellationToken)
            {
                var faqs = new Faq();
                faqs.Question = request.Answer;
                faqs.Answer = request.Answer;
                db.Add(faqs); 
                await db.SaveChangesAsync(cancellationToken);
                return faqs;
            }

            
        }

    }
}
