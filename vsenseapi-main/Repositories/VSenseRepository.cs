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
        public MEdge GetMEdge(int EdgeID)
        {
            try
            {
                var Result = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == EdgeID);
                if (Result == null)
                {
                    throw new Exception("Edge not found");
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MEdge> GetOpenMEdges()
        {
            try
            {
                var Result = _dbContext.MEdges.Where(t=>t.Status=="20" && t.ParantEdgeID!=null).ToList();
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
                    edge.Battery = 100;
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
                        asset.Status = assetView.Status;
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
                    assign.AssignmentID = default;
                    assign.AssetID = AssetID;
                    assign.EndDateTime = new DateTime(9999,12,31);
                    assign.IsActive = true;
                    assign.CreatedOn = DateTime.Now;
                    var res=_dbContext.MEdgeAssigns.Add(assign);
                    var edge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == assign.EdgeID);
                    await _dbContext.SaveChangesAsync();
                    edge.Status = "10";
                    await CreateAssignParams(assign.AssignParams, res.Entity.AssignmentID);
                }
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
                var assignments = _dbContext.MEdgeAssigns.Where(t => t.AssetID == AssetID).ToList();
                foreach (var assign in assignments)
                {
                    var edge = _dbContext.MEdges.FirstOrDefault(t => t.EdgeID == assign.EdgeID);
                    edge.Status = "20";
                    _dbContext.MEdgeAssigns.Remove(assign);
                    _dbContext.MEdgeAssignParams.Where(x => x.AssignmentID == assign.AssignmentID).ToList().ForEach(x => _dbContext.MEdgeAssignParams.Remove(x));
                    await _dbContext.SaveChangesAsync();
                }
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
        public List<AssetView> GetMAssets()
        {
            try
            {
                var Result = new List<AssetView>();
                var assets = _dbContext.MAssets.ToList();
                foreach (var asset in assets)
                {
                    var view = new AssetView();
                    view.AssetID = asset.AssetID;
                    view.Title = asset.Title;
                    view.Class = asset.Class;
                    view.SpaceID = asset.SpaceID;
                    view.Status = asset.Status;
                    view.IsActive = asset.IsActive;
                    view.CreatedOn = asset.CreatedOn;
                    view.CreatedBy = asset.CreatedBy;
                    view.ModifiedOn = asset.ModifiedOn;
                    view.ModifiedBy = asset.ModifiedBy;
                    view.Assignments = GetAssignments(asset.AssetID);
                    Result.Add(view);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Assignment> GetAssignments(int AssetID)
        {
            try
            {
                var Result = new List<Assignment>();
                var assignments = _dbContext.MEdgeAssigns.Where(t => t.AssetID == AssetID).ToList();
                foreach (var assignment in assignments)
                {
                    var view = new Assignment();
                    view.AssignmentID = assignment.AssignmentID;
                    view.EdgeID = assignment.EdgeID;
                    view.AssetID = assignment.AssetID;
                    view.SpaceID = assignment.SpaceID;
                    view.SiteID = assignment.SiteID;
                    view.StartDateTime = assignment.StartDateTime;
                    view.EndDateTime = assignment.EndDateTime;
                    view.Frequency = assignment.Frequency;
                    view.IsActive = assignment.IsActive;
                    view.ModifiedOn = assignment.ModifiedOn;
                    view.ModifiedBy = assignment.ModifiedBy;
                    view.CreatedOn = assignment.CreatedOn;
                    view.CreatedBy = assignment.CreatedBy;
                    view.AssignParams = _dbContext.MEdgeAssignParams.Where(t => t.AssignmentID == assignment.AssignmentID).ToList();
                    Result.Add(view);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Rule> GetRules()
        {
            try
            {
                var Result = _dbContext.Rules.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Rule> CreateRule(Rule ruleView)
        {
            try
            {
                var rule = _dbContext.Rules.FirstOrDefault(t => t.RuleID == ruleView.RuleID);
                if (rule != null)
                {
                    rule.SiteID = ruleView.SiteID;
                    rule.SpaceID = ruleView.SpaceID;
                    rule.AssetID = ruleView.AssetID;
                    rule.Threshold = ruleView.Threshold;
                    rule.SLA = ruleView.SLA;
                    rule.Level1 = ruleView.Level1;
                    rule.Level2 = ruleView.Level2;
                    rule.Level3 = ruleView.Level3;
                    rule.Notif1 = ruleView.Notif1;
                    rule.Notif2 = ruleView.Notif2;
                    rule.EmailTemplate = ruleView.EmailTemplate;
                    rule.IsActive = ruleView.IsActive;
                    rule.ModifiedOn = DateTime.Now;
                    rule.ModifiedBy = ruleView.ModifiedBy;
                    await _dbContext.SaveChangesAsync();
                    return rule;
                }
                else
                {
                    rule = ruleView;
                    rule.IsActive = true;
                    rule.CreatedOn = DateTime.Now;
                    rule.CreatedBy = ruleView.CreatedBy;
                    var res = _dbContext.Rules.Add(rule);
                    await _dbContext.SaveChangesAsync();
                    return res.Entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteRule(int ID)
        {
            try
            {
                var rule = _dbContext.Rules.FirstOrDefault(t => t.RuleID == ID);
                if (rule != null)
                {
                    _dbContext.Rules.Remove(rule);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("rule not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Log and Exception
        public List<LiveFeedView> GetLivFeeds()
        {
            try
            {
                var Result = new List<LiveFeedView>();
                var Logs = _dbContext.EdgeLogs.ToList();
                foreach (var log in Logs)
                {
                    var view = new LiveFeedView();
                    view.LogID = log.LogID;
                    view.EdgeID = log.EdgeID;
                    view.RefID = log.RefID;
                    view.DateTime = log.DateTime;
                    view.PramID = log.PramID;
                    view.Value = log.Value;
                    view.MinValue = log.MinValue;
                    view.MaxValue = log.MaxValue;
                    view.AvgValue = log.AvgValue;
                    view.Threshold = log.Threshold;
                    var assigned = _dbContext.MEdgeAssigns.FirstOrDefault(t => t.EdgeID == log.EdgeID);
                    if (assigned != null)
                    {
                        view.Site = _dbContext.MSites.Find(assigned.SiteID).Title;
                        view.Space = _dbContext.MSpaces.Find(assigned.SpaceID).Title;
                        view.Asset = _dbContext.MAssets.Find(assigned.AssetID).Title;
                        view.PramTitle = _dbContext.MEdgeAssignParams.Find(assigned.AssignmentID, log.PramID).Title;
                        Result.Add(view);
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ExceptionView> GetExceptions()
        {
            try
            {
                var Result = new List<ExceptionView>();
                var Exceptions = _dbContext.EdgeExceptions.ToList();
                foreach (var exception in Exceptions)
                {
                    var view = new ExceptionView();
                    view.ExcepID = exception.ExcepID;
                    view.Class = exception.Class;
                    view.PramID = exception.PramID;
                    view.DateTime = exception.CreatedOn;
                    view.Threshold = exception.Threshold;
                    view.AssignedTo = exception.AssignedTo;
                    view.SLAStart = exception.SLAStart;
                    view.Status = exception.Status;
                    view.Value = exception.Value;
                    var assigned = _dbContext.MEdgeAssigns.FirstOrDefault(t => t.EdgeID == exception.EdgeID);
                    if (assigned != null)
                    {
                        view.Site = _dbContext.MSites.Find(assigned.SiteID).Title;
                        view.Space = _dbContext.MSpaces.Find(assigned.SpaceID).Title;
                        view.Asset = _dbContext.MAssets.Find(assigned.AssetID).Title;
                        Result.Add(view);
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EdgeLog> CreateEdgeLog(EdgeLog Log)
        {
            try
            {
                Log.IsActive = true;
                Log.CreatedOn = DateTime.Now;
                var res = _dbContext.EdgeLogs.Add(Log);
                await _dbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AssignParamLogView> GetLastLogOfParams(int EdgeID)
        {
            try
            {
                var Result = new List<AssignParamLogView>();
                var Assignment = _dbContext.MEdgeAssigns.FirstOrDefault(t => t.EdgeID == EdgeID);
                if (Assignment == null)
                {
                    throw new Exception("assignment not founde");
                }
                var AssignParams = _dbContext.MEdgeAssignParams.Where(t => t.AssignmentID == Assignment.AssignmentID);
                foreach (var param in AssignParams)
                {
                    var log = _dbContext.EdgeLogs.OrderByDescending(t=>t.LogID).FirstOrDefault(t => t.EdgeID == EdgeID && t.PramID == param.PramID);
                    var view = new AssignParamLogView();
                    view.PramID = param.PramID;
                    view.Title = param.Title;
                    view.ActivityGraphTitle = param.ActivityGraphTitle;
                    view.Min = param.Min;
                    view.Max = param.Max;
                    view.Unit = param.Unit;
                    if (log != null)
                    {
                        view.Value = log.Value;
                        view.MinValue = log.MinValue;
                        view.MaxValue = log.MaxValue;
                        view.AvgValue = log.AvgValue;
                        view.DateTime = log.DateTime;
                        view.IsLogExist = true;
                    }
                    else
                    {
                        view.IsLogExist = false;
                    }
                    Result.Add(view);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Monitor
        public List<MonitorTableView> GetMonitorTable()
        {
            try
            {
                var Result = new List<MonitorTableView>();
                var assignments = _dbContext.MEdgeAssigns.ToList();
                foreach (var assign in assignments)
                {
                    var res = new MonitorTableView();
                    res.Asset = _dbContext.MAssets.Find(assign.AssetID).Title;
                    res.Edge = _dbContext.MEdges.Find(assign.EdgeID).Title;
                    res.EdgeID = assign.EdgeID;
                    res.Site= _dbContext.MSites.Find(assign.SiteID).Title;
                    res.Space= _dbContext.MSpaces.Find(assign.SpaceID).Title;
                    res.Status= _dbContext.MEdges.Find(assign.EdgeID).IsActive;
                    res.LastFeed = _dbContext.EdgeLogs.OrderByDescending(t => t.LogID).FirstOrDefault(t => t.EdgeID == assign.EdgeID)?.DateTime;
                    Result.Add(res);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ControlCenterFeed> GetControlCenterFeed()
        {
            try
            {
                var Result = new List<ControlCenterFeed>();
                var AssignParams = (from tb1 in _dbContext.MEdgeAssigns join
                                    tb2 in _dbContext.MEdgeAssignParams on tb1.AssignmentID equals tb2.AssignmentID
                                    select new {tb1,tb2}).ToList();
                foreach (var assignParam in AssignParams)
                {
                    var res = new ControlCenterFeed();
                    res.Asset = _dbContext.MAssets.Find(assignParam.tb1.AssetID).Title;
                    res.Site = _dbContext.MSites.Find(assignParam.tb1.SiteID).Title;
                    res.Space = _dbContext.MSpaces.Find(assignParam.tb1.SpaceID).Title;
                    res.Title = assignParam.tb2.Title;
                    res.Status = assignParam.tb2.IsActive;
                    var log = _dbContext.EdgeLogs.OrderByDescending(t => t.LogID).FirstOrDefault(t => t.EdgeID == assignParam.tb1.EdgeID && t.PramID == assignParam.tb2.PramID);
                    res.LastFeed = log?.DateTime;
                    res.Value = log?.Value;
                    Result.Add(res);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task ToggleDeviceStatus(int EdgeID)
        {
            try
            {
                var Edge = _dbContext.MEdges.Find(EdgeID);
                Edge.IsActive = !Edge.IsActive;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EdgeStatusChartData> GetEdgeStatusChartData()
        {
            try
            {
                var Logs= _dbContext.EdgeLogs.OrderBy(t=>t.DateTime).ToLookup(t => t.DateTime.Date);
                var Result = new List<EdgeStatusChartData>();
                foreach (var log in Logs)
                {
                    var EdgeAndDate = log.ToLookup(t => t.EdgeID);
                    var chartData = new EdgeStatusChartData();
                    chartData.x = log.Key;
                    chartData.y = EdgeAndDate.Count;
                    Result.Add(chartData);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
