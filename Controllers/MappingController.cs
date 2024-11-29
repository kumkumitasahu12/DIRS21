using Microsoft.AspNetCore.Mvc;
using System;
using DIRS21Interview.Models;
using DIRS21Interview.Handlers;

namespace DIRS21Interview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly MapHandler _mapHandler;

        public ReservationController(MapHandler mapHandler)
        {
            _mapHandler = mapHandler;
        }

        [HttpPost("map-internal-to-partner")]
        public ActionResult<ReservationPartnerModel> MapInternalToPartner([FromBody] ReservationInternalModel reservationInternal)
        {
            try
            {
                var reservationPartner = _mapHandler.Map(reservationInternal,
                    "DIRS21Interview.Models.ReservationInternalModel",
                    "DIRS21Interview.Models.ReservationPartnerModel") as ReservationPartnerModel;

                if (reservationPartner == null)
                {
                    return BadRequest("Mapping failed.");
                }

                return Ok(reservationPartner); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Error mapping data: {ex.Message}");
            }
        }

        [HttpPost("map-partner-to-internal")]
        public ActionResult<ReservationInternalModel> MapPartnerToInternal([FromBody] ReservationPartnerModel reservationPartner)
        {
            try
            {
                var reservationInternal = _mapHandler.Map(reservationPartner,
                    "DIRS21Interview.Models.ReservationPartnerModel",
                    "DIRS21Interview.Models.ReservationInternalModel") as ReservationInternalModel;

                if (reservationInternal == null)
                {
                    return BadRequest("Mapping failed.");
                }

                return Ok(reservationInternal); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Error mapping data: {ex.Message}");
            }
        }
    }
}
