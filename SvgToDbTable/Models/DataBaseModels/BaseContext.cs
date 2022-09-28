using Microsoft.EntityFrameworkCore;
using SolutionTestTaskFromMansur.Helpers;
using System;

namespace SolutionTestTaskFromMansur.Models.DataBaseModels
{
    public class BaseContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsUseLazyLoading { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isUseLazyLoading"></param>
        public BaseContext(bool isUseLazyLoading)
        {
            IsUseLazyLoading = isUseLazyLoading;
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseContext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(IsUseLazyLoading).UseNpgsql(DbConnectionHelper.MyDbConnectionString,
                builder => { builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null); });
        }
    }
}

