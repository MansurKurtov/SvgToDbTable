using Microsoft.EntityFrameworkCore;
using SolutionTestTaskFromMansur.Models.DataBaseModels.EntityModels;

namespace SolutionTestTaskFromMansur.Models.DataBaseModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTaskDbContext : BaseContext
    {
        /// <summary>
        /// 
        /// </summary>
        public TestTaskDbContext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isUseLazyLoading"></param>
        public TestTaskDbContext(bool isUseLazyLoading) : base(isUseLazyLoading)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<PersonalRecord> PersonalRecords { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
