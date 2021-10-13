using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riodetask.AppCode.Application.BrandsModule;
using Riodetask.AppCode.Extension;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Application.FaqsModule
{
    public class FaqsEditCommand : FaqsViewModel, IRequest<int>
    {
        public class FaqsEditCommandHandler : IRequestHandler<FaqsEditCommand, int>
        {
            readonly RioDbContext db;
            readonly IActionContextAccessor ctx;

            public FaqsEditCommandHandler(RioDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<int> Handle(FaqsEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }

                var entity = await db.Faqs.FirstOrDefaultAsync(m => m.ID == request.Id && m.DeleteByUserId == null);
                if (ctx.IsModelStateValid())
                {
                    entity.Answer = request.Answer;
                    entity.Question = request.Question;
                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }




                return 0;
            }
        }
    }
}
