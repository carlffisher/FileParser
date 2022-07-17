using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;

namespace ACSVFileParserForms1
{    
    public class CollectionOfQueries
    {
        public static ArrayList ProcessQuery(List<CSVValues.getLine> values, int query_id)
        {
            // a collection of specific queries ...

            switch (query_id)
            {
                case 1: // "Esq" in CompanyName

                    var result1 = from s in values
                                  where s.CompanyName!.Contains("Esq") // Why does this not work?
                                  group s by s.CompanyName into sg
                                  from record_group in sg
                                  orderby record_group.FirstName, record_group.LastName, record_group.CompanyName, record_group.Email
                                  select new
                                  {
                                      TotalEsq = values!.Count(s => s.CompanyName!.Contains("Esq")),
                                      ListPosition = values!.FindIndex(c => c.Email == record_group.Email), // Assuming that personal email address is unique
                                      FirstName = record_group.FirstName,
                                      LastName = record_group.LastName,
                                      CompanyName = record_group.CompanyName
                                  };


                    ArrayList arlist1 = new(result1.ToList());


                    return arlist1;

                case 2: // "Derbyshire" in County
                    var result2 = from s in values
                                  where s.County!.Contains("Derbyshire")
                                  group s by s.County into sg
                                  from record_group in sg
                                  orderby record_group.FirstName, record_group.LastName, record_group.CompanyName, record_group.Email
                                  select new
                                  {
                                      TotalInCounty = values!.Count(s => s.County!.Contains("Kent")),
                                      ListPosition = values!.FindIndex(c => c.Email == record_group.Email), // Assuming that personal email address is unique
                                      FirstName = record_group.FirstName,
                                      LastName = record_group.LastName,
                                      CompanyName = record_group.CompanyName
                                  };


                    ArrayList arlist2 = new(result2.ToList());


                    return arlist2;

                default:
                    Console.WriteLine("Error: Unknown query_id: {0} ", query_id);
                    return null!;
            }
        }
    } 
}
