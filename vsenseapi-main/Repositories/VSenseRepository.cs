using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Context;
using VSense.API.Models;

namespace VSense.API.Repositories
{
    public class VSenseRepository:IVSenseRepository
    {
        private readonly DeviceContext _dbcontext;
        public VSenseRepository(DeviceContext context)
        {
            _dbcontext = context;
        }
        #region Master
        public List<MSite> GetMSites()
        {
            try
            {
                var Result = _dbcontext.MSites.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MSite> CreateMSite(MSite mSite)
        {
            try
            {
                var site = _dbcontext.MSites.FirstOrDefault(t => t.SiteID == mSite.SiteID);
                if (site != null)
                {
                    site.Title = mSite.Title;
                    site.Geo = mSite.Geo;
                    site.Plant = mSite.Plant;
                    site.IsActive = mSite.IsActive;
                    site.ModifiedOn = DateTime.Now;
                    site.ModifiedBy = mSite.ModifiedBy;
                    await _dbcontext.SaveChangesAsync();
                    return site;
                }
                else
                {
                    site = mSite;
                    site.IsActive = true;
                    site.CreatedOn = DateTime.Now;
                    site.CreatedBy = mSite.CreatedBy;
                    var res = _dbcontext.MSites.Add(site);
                    await _dbcontext.SaveChangesAsync();
                    return res.Entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteMSite(int ID)
        {
            try
            {
                var mSite = _dbcontext.MSites.FirstOrDefault(t => t.SiteID == ID);
                if (mSite != null)
                {
                    _dbcontext.MSites.Remove(mSite);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("site not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MSpace> GetMSpaces()
        {
            try
            {
                var Result = _dbcontext.MSpaces.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MSpace> CreateMSpace(MSpace mSpace)
        {
            try
            {
                var space = _dbcontext.MSpaces.FirstOrDefault(t => t.SpaceID == mSpace.SpaceID);
                if (space != null)
                {
                    space.Title = mSpace.Title;
                    space.WorkCenter = mSpace.WorkCenter;
                    space.ParantSpaceID = mSpace.ParantSpaceID;
                    space.SiteID = mSpace.SiteID;
                    space.IsActive = mSpace.IsActive;
                    space.ModifiedOn = DateTime.Now;
                    space.ModifiedBy = mSpace.ModifiedBy;
                    await _dbcontext.SaveChangesAsync();
                    return space;
                }
                else
                {
                    space = mSpace;
                    space.IsActive = true;
                    space.CreatedOn = DateTime.Now;
                    space.CreatedBy = mSpace.CreatedBy;
                    var res = _dbcontext.MSpaces.Add(space);
                    await _dbcontext.SaveChangesAsync();
                    return res.Entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteMSpace(int ID)
        {
            try
            {
                var mSpace = _dbcontext.MSpaces.FirstOrDefault(t => t.SiteID == ID);
                if (mSpace != null)
                {
                    _dbcontext.MSpaces.Remove(mSpace);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("space not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MEdge> GetMEdges()
        {
            try
            {
                var Result = _dbcontext.MEdges.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MEdge> CreateMEdge(MEdge mEdge)
        {
            try
            {
                var edge = _dbcontext.MEdges.FirstOrDefault(t => t.EdgeID == mEdge.EdgeID);
                if (edge != null)
                {
                    edge.Title = mEdge.Title;
                    edge.IsActive = mEdge.IsActive;
                    edge.ModifiedOn = DateTime.Now;
                    edge.ModifiedBy = mEdge.ModifiedBy;
                    await _dbcontext.SaveChangesAsync();
                    return edge;
                }
                else
                {
                    edge = mEdge;
                    edge.IsActive = true;
                    edge.CreatedOn = DateTime.Now;
                    var res = _dbcontext.MEdges.Add(edge);
                    await _dbcontext.SaveChangesAsync();
                    return res.Entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteMEdge(int ID)
        {
            try
            {
                var mEdge = _dbcontext.MEdges.FirstOrDefault(t => t.EdgeID == ID);
                if (mEdge != null)
                {
                    _dbcontext.MEdges.Remove(mEdge);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("edge not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
