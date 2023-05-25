using System.Data;

namespace eCoreTestChallange.Data.PageData
{
    public class LoginData
    {
        public static DataTable? testData;
     
        public String?  Username { get; set; }
        public String? Password { get; set; }

        public static DataTable NegativeLoginTestData()
        {
            testData = new DataTable();
            testData.Columns.Add("Data", typeof(LoginData));
            testData.Rows.Add(new LoginData
            {
                Username = "Demouser",
                Password = "abc123"
            });
            testData.Rows.Add(new LoginData
            {
                Username = "demouser_",
                Password = "xyz"
            });
            testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "nananana"
            });
            testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "abc123"
            });
            return testData;
        }

        public static DataTable PositiveLoginTestData()
        {
            testData = new DataTable();
            testData.Columns.Add("Data", typeof(LoginData));
            testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "abc123"
            });
            return testData;
        }      
    }
}
