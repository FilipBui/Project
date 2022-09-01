using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpearSharp.Services;

namespace SpearSharp.Controllers
{
    [Route("leaderboards")]
    public class LeaderboardsController : Controller
    {
        public readonly ILeaderboardsService leaderboardsService;

        public LeaderboardsController(ILeaderboardsService leaderboardsService)
        {
            this.leaderboardsService = leaderboardsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("troops")]
        public IActionResult Troops()
        {
            return Json(leaderboardsService.GetTroopsLeaderboardDTOs());
        }
        [HttpGet("buildings")]
        public IActionResult Buildings()
        {
            return Json(leaderboardsService.GetBuildingsLeaderboardDTOs());
        }
        [HttpGet("kingdoms")]
        public IActionResult Kingdoms()
        {
            return Json(leaderboardsService.GetKingdomsLeaderboardDTOs());
        }
    }
}

