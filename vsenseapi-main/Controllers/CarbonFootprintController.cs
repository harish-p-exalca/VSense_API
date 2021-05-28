using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Repositories;
using VSign;

namespace VSense.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarbonFootprintController : ControllerBase
    {
        private readonly ICFRepository repo;
        public CarbonFootprintController(ICFRepository repository)
        {
            repo = repository;
        }
        [HttpGet]
        public IActionResult GetAllWaterDevices()
        {
            try
            {
                return Ok(repo.GetAllWaterDevices());
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("CarbonFootprint/GetAllWaterDevices", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllCurrentDevices()
        {
            try
            {
                return Ok(repo.GetAllCurrentDevices());
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("CarbonFootprint/GetAllCurrentDevices", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetWaterConsumption(string deviceid)
        {
            try
            {
                var res = repo.GetWaterConsumption(deviceid);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("CarbonFootprint/GetWaterConsumption", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetCurrentConsumption(string deviceid)
        {
            try
            {
                var res = repo.GetCurrentConsumption(deviceid);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("CarbonFootprint/GetCurrentConsumption", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetEnergyConsumption(string deviceid)
        {
            try
            {
                var res = repo.GetEnergy(deviceid);
                return Ok(res);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("CarbonFootprint/GetEnergyConsumption", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
