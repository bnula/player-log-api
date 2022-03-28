using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayerLogApi.Data.Models;
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
    public class CampaignController : Controller
    {
        private readonly ISender _sender;

        public CampaignController(ISender sender)
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
    }
}
