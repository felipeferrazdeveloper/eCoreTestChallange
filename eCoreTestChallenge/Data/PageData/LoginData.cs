using System.Data;

namespace eCoreTestChallenge.Data.PageData
{
    public record LoginData : BaseData
    {
        protected static DataTable? _testData;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public static DataTable NegativeLoginTestData()
        {
            _testData = new DataTable();
            _testData.Columns.Add("Data", typeof(LoginData));
            _testData.Rows.Add(new LoginData
            {
                Username = "Demouser",
                Password = "abc123"
            });
            _testData.Rows.Add(new LoginData
            {
                Username = "demouser_",
                Password = "xyz"
            });
            _testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "nananana"
            });
            _testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "abc123"
            });
            return _testData;
        }

        public static DataTable PositiveLoginTestData()
        {
            _testData = new DataTable();
            _testData.Columns.Add("Data", typeof(LoginData));
            _testData.Rows.Add(new LoginData
            {
                Username = "demouser",
                Password = "abc123"
            });
            return _testData;
        }
    }
}