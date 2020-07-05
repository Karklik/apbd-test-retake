using System;
using System.Linq;
using apbd_test_retake.DTOs;
using apbd_test_retake.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test_retake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirefightesController : ControllerBase
    {
        private readonly IFireBrigadeDbService service;
        public FirefightesController(IFireBrigadeDbService service)
        {
            this.service = service;
        }

        [HttpGet("{id}/actions")]
        public IActionResult GetActions(int id)
        {
            try
            {
                var firefighter = service.GetFirefighter(id);
                if (firefighter == null)
                    return NotFound("Firefighter not found");
                return Ok(firefighter.FirefighterActions.Select(fa => new GetActionsResponse
                {
                    IdAction = fa.IdAction,
                    StartTime = fa.Action.StartTime,
                    EndTime = fa.Action.EndTime
                }).OrderByDescending(r => r.EndTime).ToList());
            }
            catch (Exception) { }

            return StatusCode(500, "Something went wrong");
        }
    }
}