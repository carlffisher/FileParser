using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;
using ACSVFileParserForms1;
using System.Collections;

namespace ACSVFileParser
{
    public class Tests
    {
        public static List<CSVValues.getLine>? values;
        public string? filePathString;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInitialiseTest()
        {
            Assert.Pass();
        }

        [Test]
        public void TestReadCSVFileAndReturnStringList()
        {
            // Test for correct retrieval of data from testcsvfile1.csv ...

            const int NUMBEROFROWS = 7;
            const int NUMBEROFCOLUMNS = 11;


            System.IO.Directory.SetCurrentDirectory("D:/Users/carlf/source/repos/AFileParser/");
            filePathString = Path.Combine(Directory.GetCurrentDirectory(), "csv", "testcsvfile1.csv");

            // List<CSVValues.getLine> values = File.ReadAllLines(filePathString)
            values = File.ReadAllLines(filePathString)
                                               .Skip(1)
                                               .Select(v => CSVValues.getLine.FromCsv(v))
                                               .ToList();

            // Test for correct no of rows and columns returned from testcsvfile1.csv ...

            values.Count.Should().Be(NUMBEROFROWS);

            for (int i = 0; i < NUMBEROFROWS; i++)
                values.Count.Should().Be(NUMBEROFCOLUMNS);


            // Test for return of correct types for first and last columns returned from testcsvfile1.csv ...

            for (int i = 0; i < values.Count; i++)
            {
                values[i].FirstName.Should().NotBeNullOrWhiteSpace();
                values[i].LastName.Should().NotBeNullOrWhiteSpace();
                values[i].CompanyName.Should().NotBeNullOrWhiteSpace();
                values[i].Address.Should().NotBeNullOrWhiteSpace();
                values[i].City.Should().NotBeNullOrWhiteSpace();
                values[i].County.Should().NotBeNullOrWhiteSpace();
                values[i].Postal.Should().NotBeNullOrWhiteSpace();
                values[i].Phone1.Should().NotBeNullOrWhiteSpace();
                values[i].Phone2.Should().NotBeNullOrWhiteSpace();
                values[i].Email.Should().NotBeNullOrWhiteSpace();
                values[i].Web.Should().NotBeNullOrWhiteSpace();
            }

            // Test some items returned from testcsvfile1.csv ...

            var results1 = from s in values
                           where s.County!.Contains("Kent")
                           select s;

            foreach (var item in results1)
            {
                item.County.Should().NotBeNullOrWhiteSpace();
                item.County.Should().Contain("Derbyshire");
            }

            var totalDerbyshire = values.Count(s => s.County!.Contains("Derbyshire"));
            totalDerbyshire.Should().Be(7);
        }

        [Test]
        public void TestQueryReturnsCorrectResult2()
        {
            // Test returned data from query 2 ...
            System.IO.Directory.SetCurrentDirectory("D:/Users/carlf/source/repos/AFileParser/");
            filePathString = Path.Combine(Directory.GetCurrentDirectory(), "csv", "testcsvfile1.csv");
            
            values = File.ReadAllLines(filePathString)
                                               .Skip(1)
                                               .Select(v => CSVValues.getLine.FromCsv(v))
                                               .ToList();

            // Test returned data from query 2 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(values, 2); //Send file and id of query
            
            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} " );

            resultarraylist.Count.Should().Be(7);

        }
    }
}