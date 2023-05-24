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
    }
}
