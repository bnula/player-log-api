using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Handlers.Campaigns.Command
{
    public class UpdateCampaignCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public CampaignUpdate Campaign { get; set; }
    }

    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommandRequest, Unit>
    {
        private readonly PlayerLogDbContext _dbContext;

        public UpdateCampaignCommandHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            var camp = await _dbContext.Campaigns.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            
            if (camp is null)
            {
                return Unit.Value;
            }
            
            camp.Name = request.Campaign.Name;

            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
