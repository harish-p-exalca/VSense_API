using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Models;
using VSense.API.Repositories;
using VSign;

namespace VSense.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VSenseController : ControllerBase
    {
        private readonly IVSenseRepository _repository;
        public VSenseController(IVSenseRepository repository)
        {
            _repository = repository;
        }
        #region Master
        [HttpPost]
        public async Task<IActionResult> CreateMSite(MSite site)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateMSite(site);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateMSite", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMSite(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteMSite(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteMSite", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<MSite> GetMSites()
        {
            try
            {
                var Result = _repository.GetMSites();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetMSites", ex);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMSpace(MSpace space)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateMSpace(space);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateMSpace", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMSpace(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteMSpace(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteMSpace", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<MSpace> GetMSpaces()
        {
            try
            {
                var Result = _repository.GetMSpaces();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetMSpaces", ex);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMEdge(MEdge edge)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateMEdge(edge);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateMEdge", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMEdge(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteMEdge(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteMEdge", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<MEdge> GetMEdges()
        {
            try
            {
                var Result = _repository.GetMEdges();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetMEdges", ex);
                return null;
            }
        }
        [HttpGet]
        public List<MEdge> GetOpenMEdges()
        {
            try
            {
                var Result = _repository.GetOpenMEdges();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetOpenMEdges", ex);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMEdgeGroup(MEdgeGroupView groupView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateMEdgeGroup(groupView);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateMEdgeGroup", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMEdgeGroup(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteMEdgeGroup(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteMEdgeGroup", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<MEdgeGroupView> GetMEdgeGroups()
        {
            try
            {
                var Result = _repository.GetMEdgeGroups();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetMEdgeGroups", ex);
                return null;
            }
        }
        [HttpGet]
        public List<AssetView> GetMAssets()
        {
            try
            {
                var Result = _repository.GetMAssets();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetMAssets", ex);
                return null;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMAsset(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteMAsset(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteMAsset", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMAsset(AssetView assetView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateMAsset(assetView);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateMAsset", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateRule(Rule rule)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _repository.CreateRule(rule);
                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/CreateRule", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRule(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _repository.DeleteRule(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/DeleteRule", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<Rule> GetRules()
        {
            try
            {
                var Result = _repository.GetRules();
                return Result;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToFile("Master/GetRules", ex);
                return null;
            }
        }
        #endregion
    }
}
