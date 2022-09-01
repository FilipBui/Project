using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpearSharp.Models;
using SpearSharp.Services;
using SpearSharp.Database;
using Microsoft.AspNetCore.Mvc;
using SpearSharp.Models.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpearSharp.Controllers
{
    [Route("kingdoms")]
    public class KingdomsController : Controller
    {
        
            private readonly IBuildingService buildingService;
            private readonly IKingdomService kingdomService;
            private readonly ITroopsService troopsService;
            private ApplicationDbContext data;

            public KingdomsController(IKingdomService kingdomService, IBuildingService buildingService, ApplicationDbContext data, ITroopsService troopsService)
            {
                this.data = data;
                this.buildingService = buildingService;
                this.kingdomService = kingdomService;
                this.troopsService = troopsService;
            }

            [HttpGet("")]
            public IActionResult Kingdoms()
            {
                return Json(kingdomService.GetKingdoms());
            }

            [HttpPost("{id}/buildings")]
            public IActionResult AddBuilding([FromRoute] int id, string buildingType)
            {
                if (buildingService.AreBuildingRequirementsMet(id, buildingType))
                {
                    return Json(buildingService.AddBuilding(id, buildingType));
                }
                else if (string.IsNullOrEmpty(buildingType))
                {
                    return BadRequest("error: Type is required");
                }
                else if ((buildingService.AreBuildingRequirementsMet(id, buildingType)))
                {
                    return BadRequest("error: You don't have enough gold");
                }
                else if (data.Kingdoms.SingleOrDefault(k => k.Id == id) == null)
                {
                    return StatusCode(401, "error: This kingdom does not belong to authenticated player");
                }
                return Ok();
            }

            [HttpGet("{id}")]
            public IActionResult KingdomDetails(int id)
            {
                KingdomDetailsDTO kingdomDetailsDTO = kingdomService.GetKingdomDetails(id);

                if (kingdomDetailsDTO == null)
                {
                    var error = new { error = "This kingdom does not belong to authenticated player" };
                    return StatusCode(401, error);
                }
                return Json(kingdomDetailsDTO);
            }

            [HttpPut("{id}/rename")]
            public IActionResult RenameKingdom(int id, string kingdomName)
            {
                if (string.IsNullOrEmpty(kingdomName))
                {
                    var error = new { error = "Field kingdomName was empty!" };
                    return StatusCode(400, error);
                }
                return Json(kingdomService.RenameKingdom(id, kingdomName));
            }

            [HttpGet("{id}/troops")]
            public IActionResult KingdomTroops(int id)
            {
                return Json(kingdomService.GetKingdomDTOById(id), troopsService.GetTroopsListDTOByKingdomId(id));
            }
        }
    }


