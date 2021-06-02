using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Models;

namespace VSense.API.Repositories
{
    public interface IVSenseRepository
    {
        #region Master
        List<MSite> GetMSites();
        Task<MSite> CreateMSite(MSite mSite);
        Task DeleteMSite(int ID);
        List<MSpace> GetMSpaces();
        Task<MSpace> CreateMSpace(MSpace mSpace);
        Task DeleteMSpace(int ID);
        List<MEdge> GetMEdges();
        MEdge GetMEdge(int EdgeID);
        List<MEdge> GetOpenMEdges();
        Task<MEdge> CreateMEdge(MEdge mSpace);
        Task DeleteMEdge(int ID);
        Task<MEdgeGroup> CreateMEdgeGroup(MEdgeGroupView GroupView);
        Task DeleteMEdgeGroup(int ID);
        List<MEdgeGroupView> GetMEdgeGroups();
        Task<MAsset> CreateMAsset(AssetView assetView);
        Task DeleteMAsset(int ID);
        List<AssetView> GetMAssets();
        List<Rule> GetRules();
        Task<Rule> CreateRule(Rule ruleView);
        Task DeleteRule(int ID);
        #endregion
        #region Log and Exception
        Task<EdgeLog> CreateEdgeLog(EdgeLog Log);
        List<AssignParamLogView> GetLastLogOfParams(int EdgeID);
        #endregion
        #region Monitor
        List<MonitorTableView> GetMonitorTable();
        List<ControlCenterFeed> GetControlCenterFeed();
        Task ToggleDeviceStatus(int EdgeID);
        List<EdgeStatusChartData> GetEdgeStatusChartData();
        List<LiveFeedView> GetLivFeeds();
        List<ExceptionView> GetExceptions();
        #endregion
    }
}
