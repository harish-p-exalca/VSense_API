using Microsoft.EntityFrameworkCore;
using VSense.API.Models;
namespace VSense.API.Context
{
    public class DeviceContext:DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options): base(options)
        {

        }
        
        #region EdgeContext
        public DbSet<MSite> MSites { get; set; }
        public DbSet<MSpace> MSpaces { get; set; }
        public DbSet<MAsset> MAssets { get; set; }
        public DbSet<MGroup> MGroups { get; set; }
        public DbSet<MEdgeGroupParam> MEdgeGroupParams { get; set; }
        public DbSet<MEdge> MEdges { get; set; }
        public DbSet<MEdgeAssign> MEdgeAssigns { get; set; }
        public DbSet<MEdgeAssignParam> MEdgeAssignParams { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<EdgeLog> EdgeLogs { get; set; }
        public DbSet<EdgeException> EdgeExceptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MEdgeGroupParam>().HasKey(o => new { o.EdgeGroup, o.ParamID });
            modelBuilder.Entity<MEdgeAssignParam>().HasKey(o => new { o.AssignmentID, o.PramID });
            modelBuilder.Entity<EdgeLog>().HasIndex(table => new { table.EdgeID, table.PramID });
        }
        #endregion


        #region Old
        //public DbSet<Device_log> Device_log { get; set; }
        //public DbSet<m_device> m_device { get; set; }
        //public DbSet<m_device_param> m_device_param { get; set; }
        //public DbSet<m_equipment> m_equipment { get; set; }
        //public DbSet<m_Loc> m_Loc { get; set; }
        //// public DbSet <m_TrkDo> m_TrkDo { get; set; }
        //public DbSet<t_device_assign> t_device_assign { get; set; }
        //public DbSet<t_device_assign_param> t_device_assign_param { get; set; }
        //// public DbSet <t_trkdo_assign> t_trkdo_assign { get; set; }
        //// public DbSet <t_TrkDoLog> t_TrkDoLog { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<t_device_assign_param>().HasKey(o => new { o.assignmentID, o.PramID });
        //    modelBuilder.Entity<m_device_param>().HasKey(o => new { o.DeviceID, o.ParamID });
        //    modelBuilder.Entity<m_device>()
        //        .HasMany(c => c.deviceParams)
        //        .WithOne(e => e.device);
        //}
        #endregion
    }
}