using SolutionTestTaskFromMansur.Models.DataBaseModels.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionTestTaskFromMansur.Models.DataBaseModels.EntityModels
{
    [Table("personal_records", Schema = "main")]
    public class PersonalRecord : IEntity<int>
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("payroll_number")]
        public string PayrolNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("forenames")]
        public string Forenames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("address_2")]
        public string Address_2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("email_home")]
        public string EMailHome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("start_date")]
        public DateTime? StartDate { get; set; }
    }
}
