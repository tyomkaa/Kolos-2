using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDBService dBService;
        public HomeController(IDBService dBService)
        {
            this.dBService = dBService;
        }


        [HttpGet("{TeamID}")]
        public async Task<IActionResult> GetTeam(int TeamID)
        {
            try
            {
                var result = await dBService.GetTeam(TeamID);
                return Ok(result);
            }
            catch 
            {
                throw new Exception();
            }
        }

       [HttpPost]
       public async Task<ActionResult> AddMember(int MemberID, int TeamID)
        {
            var result = await dBService.AddMember(MemberID, TeamID);
            switch (result)
            {
                case 0: return Ok();
                case 2: return BadRequest("This member is not a part of that team");
                default: throw new Exception();
            }
        }
    }
}
