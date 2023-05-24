using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoreTestChallange
{
    public static class TestData
    {
        public static DataTable testData;       

        public static DataTable PositiveLogin()
        {
            testData = new DataTable();

            testData.Columns.Add("username", typeof(string));
            testData.Columns.Add("password", typeof(string));

            testData.Rows.Add("demouser", "abc123");
            return testData;
        }

        public static DataTable NegativeLogin()
        {
            testData = new DataTable();

            testData.Columns.Add("username", typeof(string));
            testData.Columns.Add("password", typeof(string));

            testData.Rows.Add("Demouser", "abc123");
            testData.Rows.Add("demouser_", "xyz");
            testData.Rows.Add("demouser", "nananana");
            testData.Rows.Add("demouser", "abc123");
            return testData;
        }
    }
}
