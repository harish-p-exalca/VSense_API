using Microsoft.EntityFrameworkCore;
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
        private readonly DeviceContext _dbContext;
        public VSenseRepository(DeviceContext context)
        {
            _dbContext = context;
        }
        #region Master
        public List<MSite> GetMSites()
        {
            try
            {
                var Result = _dbContext.MSites.ToList();
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
                var site = _dbContext.MSites.FirstOrDefault(t => t.SiteID == mSite.SiteID);
                if (site != null)
                {
                    site.Title = mSite.Title;
                    site.Geo = mSite.Geo;
                    site.Plant = mSite.Plant;
                    site.IsActive = mSite.IsActive;
                    site.ModifiedOn = DateTime.Now;
                    site.ModifiedBy = mSite.ModifiedBy;
                    await _dbContext.SaveChangesAsync();
                    return site;
                }
                else
                {
                    site = mSite;
                    site.IsActive = true;
                    site.CreatedOn = DateTime.Now;
                    site.CreatedBy = mSite.CreatedBy;
                    var res = _dbContext.MSites.Add(site);
                    await _dbContext.SaveChangesAsync();
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
                var mSite = _dbContext.MSites.FirstOrDefault(t => t.SiteID == ID);
                if (mSite != null)
                {
                    _dbContext.MSites.Remove(mSite);
                    await _dbContext.SaveChangesAsync();
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
                var Result = _dbContext.MSpaces.ToList();
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
                var space = _dbContext.MSpaces.FirstOrDefault(t => t.SpaceID == mSpace.SpaceID);
                if (space != null)
                {
                    space.Title = mSpace.Title;
                    space.WorkCenter = mSpace.WorkCenter;
                    space.ParantSpaceID = mSpace.ParantSpaceID;
                    space.SiteID = mSpace.SiteID;
                    space.IsActive = mSpace.IsActive;
                    space.ModifiedOn = DateTime.Now;
                    space.ModifiedBy = mSpace.ModifiedBy;
                    await _dbContext.SaveChangesAsync();
                    return space;
                }
                else
                {
                    space = mSpace;
                    space.IsActive = true;
                    space.CreatedOn = DateTime.Now;
                    space.CreatedBy = mSpace.CreatedBy;
                    var res = _dbContext.MSpaces.Add(space);
                    await _dbContext.SaveChangesAsync();
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
                var mSpace = _dbContext.MSpaces.FirstOrDefault(t => t.SpaceID == ID);
                if (mSpace != null)
                {
                    _dbContext.MSpaces.Remove(mSpace);
                    await _dbContext.SaveChangesAsync();
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
                var Result = _dbContext.MEdges.ToList();
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
                var edge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == mEdge.EdgeID);
                if (edge != null)
                {
                    edge.Title = mEdge.Title;
                    edge.PuttoUse = mEdge.PuttoUse;
                    edge.Battery = mEdge.Battery;
                    edge.SoftwareVersion = mEdge.SoftwareVersion;
                    edge.Vcc = mEdge.Vcc;
                    edge.Lifespan = mEdge.Lifespan;
                    edge.EdgeGroup = mEdge.EdgeGroup;
                    edge.Status = mEdge.Status;
                    edge.ParantEdgeID = mEdge.ParantEdgeID;
                    edge.IsActive = mEdge.IsActive;
                    edge.ModifiedOn = DateTime.Now;
                    edge.ModifiedBy = mEdge.ModifiedBy;
                    await _dbContext.SaveChangesAsync();
                    return edge;
                }
                else
                {
                    edge = mEdge;
                    edge.Status = "20";
                    edge.IsActive = true;
                    edge.CreatedOn = DateTime.Now;
                    var res = _dbContext.MEdges.Add(edge);
                    await _dbContext.SaveChangesAsync();
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
                var mEdge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == ID);
                if (mEdge != null)
                {
                    _dbContext.MEdges.Remove(mEdge);
                    await _dbContext.SaveChangesAsync();
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
        public async Task<MEdgeGroup> CreateMEdgeGroup(MEdgeGroupView GroupView)
        {
            var Result = new MEdgeGroup();
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    MEdgeGroup group = _dbContext.MEdgeGroups.FirstOrDefault(t => t.EdgeGroup == GroupView.EdgeGroup);
                    if (group != null)
                    {
                        group.Title = GroupView.Title;
                        group.IsActive = GroupView.IsActive;
                        group.ModifiedOn = DateTime.Now;
                        group.ModifiedBy = GroupView.ModifiedBy;
                        await _dbContext.SaveChangesAsync();
                        _dbContext.MEdgeGroupParams.Where(x => x.EdgeGroup == GroupView.EdgeGroup).ToList().ForEach(x => _dbContext.MEdgeGroupParams.Remove(x));
                        await _dbContext.SaveChangesAsync();
                        await CreateMEdgeGroupParams(GroupView.EdgeParams, GroupView.EdgeGroup);
                        Result = group;
                    }
                    else
                    {
                        group = (MEdgeGroup)GroupView;
                        group.IsActive = true;
                        group.CreatedOn = DateTime.Now;
                        var res = _dbContext.MEdgeGroups.Add(group);
                        await _dbContext.SaveChangesAsync();
                        await CreateMEdgeGroupParams(GroupView.EdgeParams, res.Entity.EdgeGroup);
                        Result = res.Entity;
                    }
                    transaction.Commit();
                    transaction.Dispose();
                    return Result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    throw ex;
                }
            });
            return Result;
        }
        public async Task CreateMEdgeGroupParams(List<MEdgeGroupParam> groupParams,int group) {
            try
            {
                foreach (var param in groupParams)
                {
                    param.EdgeGroup = group;
                    param.IsActive = true;
                    param.CreatedOn = DateTime.Now;
                    _dbContext.MEdgeGroupParams.Add(param);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteMEdgeGroup(int ID)
        {
            try
            {
                var group = _dbContext.MEdgeGroups.FirstOrDefault(t => t.EdgeGroup == ID);
                if (group != null)
                {
                    _dbContext.MEdgeGroups.Remove(group);
                    _dbContext.MEdgeGroupParams.Where(x => x.EdgeGroup == ID).ToList().ForEach(x => _dbContext.MEdgeGroupParams.Remove(x));
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("edge group not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MEdgeGroupView> GetMEdgeGroups()
        {
            try
            {
                var Result = new List<MEdgeGroupView>();
                var groups = _dbContext.MEdgeGroups.ToList();
                foreach (var group in groups)
                {
                    var groupView = new MEdgeGroupView();
                    groupView.EdgeGroup = group.EdgeGroup;
                    groupView.Title = group.Title;
                    groupView.IsActive = group.IsActive;
                    groupView.CreatedBy = group.CreatedBy;
                    groupView.CreatedOn = group.CreatedOn;
                    groupView.ModifiedBy = group.ModifiedBy;
                    groupView.ModifiedOn = group.ModifiedOn;
                    groupView.EdgeParams = _dbContext.MEdgeGroupParams.Where(t => t.EdgeGroup == group.EdgeGroup).ToList();
                    Result.Add(groupView);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MAsset> CreateMAsset(AssetView assetView)
        {
            var Result = new MAsset();
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = _dbContext.Database.BeginTransaction();
                try
                {
                    MAsset asset = _dbContext.MAssets.FirstOrDefault(t => t.AssetID == assetView.AssetID);
                    if (asset != null)
                    {
                        asset.Title = assetView.Title;
                        asset.Class = assetView.Class;
                        asset.SpaceID = assetView.SpaceID;
                        asset.IsActive = assetView.IsActive;
                        asset.ModifiedOn = DateTime.Now;
                        asset.ModifiedBy = assetView.ModifiedBy;
                        await _dbContext.SaveChangesAsync();
                        await RemoveAssignment(assetView.AssetID);
                        await CreateAssignments(assetView.Assignments, assetView.AssetID);
                        Result = asset;
                    }
                    else
                    {
                        asset = (MAsset)assetView;
                        asset.IsActive = true;
                        asset.CreatedOn = DateTime.Now;
                        var res = _dbContext.MAssets.Add(asset);
                        await _dbContext.SaveChangesAsync();
                        await CreateAssignments(assetView.Assignments, res.Entity.AssetID);
                        Result = res.Entity;
                    }
                    transaction.Commit();
                    transaction.Dispose();
                    return Result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    throw ex;
                }
            });
            return Result;
        }
        public async Task CreateAssignments(List<Assignment> assignments, int AssetID)
        {
            try
            {
                foreach (var assign in assignments)
                {
                    assign.AssetID = AssetID;
                    assign.EndDateTime = new DateTime(9999,12,31);
                    assign.IsActive = true;
                    assign.CreatedOn = DateTime.Now;
                    var res=_dbContext.MEdgeAssigns.Add(assign);
                    var edge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == assign.EdgeID);
                    edge.Status = "10";
                    await CreateAssignParams(assign.AssignParams, res.Entity.AssignmentID);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task CreateAssignParams(List<MEdgeAssignParam> assignParams, int AssignmentID)
        {
            try
            {
                foreach (var assignParam in assignParams)
                {
                    assignParam.AssignmentID = AssignmentID;
                    assignParam.IsActive = true;
                    assignParam.CreatedOn = DateTime.Now;
                    _dbContext.MEdgeAssignParams.Add(assignParam);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task RemoveAssignment(int AssetID)
        {
            try
            {
                var assignments = _dbContext.MEdgeAssigns.Where(t => t.AssignmentID == AssetID);
                foreach (var assign in assignments)
                {
                    var edge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == assign.EdgeID);
                    edge.Status = "20";
                    _dbContext.MEdgeAssigns.Remove(assign);
                    _dbContext.MEdgeAssignParams.Where(x => x.AssignmentID == AssetID).ToList().ForEach(x => _dbContext.MEdgeAssignParams.Remove(x));
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteMAsset(int ID)
        {
            try
            {
                var asset = _dbContext.MAssets.FirstOrDefault(t => t.AssetID == ID);
                if (asset != null)
                {
                    _dbContext.MAssets.Remove(asset);
                    await _dbContext.SaveChangesAsync();
                    await RemoveAssignment(ID);
                }
                else
                {
                    throw new Exception("asset not found");
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
