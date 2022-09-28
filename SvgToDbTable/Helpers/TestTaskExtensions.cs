using SolutionTestTaskFromMansur.Models.DataBaseModels.EntityModels;
using System;

namespace SolutionTestTaskFromMansur.Helpers
{
    public static class TestTaskExtensions
    {
        public static PersonalRecord ToPersonalRecord(this string[] rowData)
        {
            if (rowData.Length < 11)
                return null;

            DateTime dt;

            var result = new PersonalRecord();
            result.PayrolNumber = rowData[0];
            result.Forenames = rowData[1];
            result.Surname = rowData[2];

            DateTime.TryParse(rowData[3], out dt) ;
            result.DateOfBirth = dt;
            
            result.Telephone = rowData[4];
            result.Mobile = rowData[5];
            result.Address = rowData[6];
            result.Address_2 = rowData[7];
            result.Postcode = rowData[8];
            result.EMailHome = rowData[9];

            DateTime.TryParse(rowData[10], out dt);
            result.StartDate = dt;

            return result;
        }
    }
}
