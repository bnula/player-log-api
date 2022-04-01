using MediatR;
using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Handlers.Campaigns.Command
{
    public class DeleteCampaignCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommandRequest, Unit>
    {
        private readonly PlayerLogDbContext _dbContext;

        public DeleteCampaignCommandHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            var campaign = await _dbContext.Campaigns.Where(c => c.CampaignId == request.Id).FirstOrDefaultAsync();
            if (campaign == null)
            {
                return Unit.Value;
            }

            _dbContext.Campaigns.Remove(campaign);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return Unit.Value;
        }
    }
}
