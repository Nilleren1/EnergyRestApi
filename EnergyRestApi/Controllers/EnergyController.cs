using System.Collections.Generic;
using EnergyRestApi.Managers;
using EngergyLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnergyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        private EnergyManager _manager = new EnergyManager();


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<EnergyData>> GetAll([FromQuery] string value)
        {
            List<EnergyData> result = _manager.GetAllData(value);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<EnergyData> Post([FromBody] EnergyData newData)
        {
            EnergyData createdData = new EnergyData();
            if (newData.EnergyMetric == null || newData.Value < 0)
            {
                return BadRequest();
            }
            createdData = _manager.AddCooler(newData);
            return Created("api/EnergyData/" + createdData.Id, createdData);
        }
    }
}
