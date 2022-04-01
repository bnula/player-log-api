using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayerLogApi.Data.Models;
using PlayerLogApi.Handlers.Campaigns.Command;
using PlayerLogApi.Handlers.Campaigns.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CampaignsController : Controller
    {
        private readonly ISender _sender;

        public CampaignsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CampaignResult> FindCampaigns()
        {
            var request = new FindCampaignsQueryRequest();
            var result = await _sender.Send(request);
            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCampaign(int id)
        {
            var request = new GetCampaignQueryRequest { Id = id };
            var result = await _sender.Send(request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Campaign))]
        public async Task<IActionResult> CreateCampaign(CreateCampaignCommandRequest request)
        {
            var id = await _sender.Send(request);
            var result = await _sender.Send(new GetCampaignQueryRequest { Id = id });
            return CreatedAtAction(nameof(GetCampaign), new { id = id }, result);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Campaign))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCampaign(int id, CampaignUpdate patch)
        {
            var request = new UpdateCampaignCommandRequest { Id = id, Campaign = patch };

            await _sender.Send(request);
            var result = await _sender.Send(new GetCampaignQueryRequest { Id = id });
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
