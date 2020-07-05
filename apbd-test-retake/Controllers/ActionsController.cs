using apbd_test_retake.DTOs;
using apbd_test_retake.Models;
using apbd_test_retake.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace apbd_test_retake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly IFireBrigadeDbService service;
        public ActionsController(IFireBrigadeDbService service)
        {
            this.service = service;
        }

        [HttpPost("{id}/fire-trucks")]
        public IActionResult AddFireTruck(int id, AddFireTruckRequest request)
        {
            try
            {
                if (id != request.IdAction)
                    return BadRequest("Inconsistent IdAction");

                var action = service.GetAction(request.IdAction);
                if (action == null)
                    return NotFound("Action not found");

                var fireTruck = service.GetFireTruck(request.IdFireTruck);
                if (fireTruck == null)
                    return NotFound("FireTruck not found");

                if (fireTruck.FireTruckActions.Where(fa => fa.Action.EndTime != null).FirstOrDefault() == null)
                    return Conflict("FireTruck is already on difrent action");

                if (action.NeedSpecialEquipment == true && fireTruck.SpecialEquipment == false)
                    return BadRequest("Action requires special equipment but fire truck does not have it");

                if (action.FireTruckActions.Where(fa => fa.IdFireTruck == fireTruck.IdFireTruck).FirstOrDefault() != null)
                    return Conflict("FireTruck already assigned to action");

                var newFireTruckAction = new FireTruckAction
                {
                    IdFireTruck = fireTruck.IdFireTruck,
                    IdAction = action.IdAction,
                    AssigmentDate = DateTime.Now
                };

                var addedFireTruckAction = service.AddFireTruckAction(newFireTruckAction);

                if (addedFireTruckAction != null)
                    return Ok(addedFireTruckAction);
            }
            catch (Exception) { }

            return StatusCode(500, "Something went wrong");
        }
    }
}