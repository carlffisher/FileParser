using System;
using System.Collections.Generic;

namespace ACSVFileParserForms1
{
    public class CSVValues
    {
        // Reads and returns every line in csv file ...

        public  class getLine
        {
            public string? FirstName;
            public string? LastName;
            public string? CompanyName;
            public string? Address;
            public string? City;
            public string? County;
            public string? Postal;
            public string? Phone1;
            public string? Phone2;
            public string? Email;
            public string? Web;


            public static getLine FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(',');
                getLine getCSVRow = new getLine();

                getCSVRow.FirstName   = values[0];
                getCSVRow.LastName    = values[1];
                getCSVRow.CompanyName = values[2];
                getCSVRow.Address     = values[3];
                getCSVRow.City        = values[4];
                getCSVRow.County      = values[5];
                getCSVRow.Postal      = values[6];
                getCSVRow.Phone1      = values[7];
                getCSVRow.Phone2      = values[8];
                getCSVRow.Email       = values[9];
                getCSVRow.Web         = values[10];

                return getCSVRow;
            }
        }
    }
}
