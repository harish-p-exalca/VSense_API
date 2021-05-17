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
        Task<MEdge> CreateMEdge(MEdge mSpace);
        Task DeleteMEdge(int ID);
        #endregion
    }
}
