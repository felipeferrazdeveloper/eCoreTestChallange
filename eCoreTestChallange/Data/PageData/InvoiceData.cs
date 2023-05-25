using System.Data;

namespace eCoreTestChallange.Data.PageData
{
    public class InvoiceData : LoginData
    {        
        public String? HotelName { get; set; }
        public String? InvoiceDate { get; set; }
        public String? DueDate { get; set; }
        public String? InvoiceNumber { get; set; }
        public String? BookingCode { get; set; }
        public String? CustomerDetails { get; set; }
        public String? Room { get; set; }
        public String? CheckIn { get; set; }
        public String? CheckOut { get; set; }
        public String? TotalStayCount { get; set; }
        public String? TotalStayAmount { get; set; }
        public String? DepositNow { get; set; }
        public String? TaxAndVAT { get; set; }
        public String? TotalAmount { get; set; }

        public static DataTable SampleInvoiceTestData()
        {
            testData = new DataTable();
            testData.Columns.Add("Data", typeof(InvoiceData));
            testData.Rows.Add(new InvoiceData
            {
                Username = "demouser",
                Password = "abc123",

                HotelName = "Rendezvous Hotel",
                InvoiceDate = "14/01/2018",
                DueDate = "15/01/2018",
                InvoiceNumber = "110",
                BookingCode = "0875",
                CustomerDetails = "JOHNY SMITH\r\nR2, AVENUE DU MAROC\r\n123456",
                Room = "Superior Double",
                CheckIn = "14/01/2018",
                CheckOut = "15/01/2018",
                TotalStayCount = "1",
                TotalStayAmount = "$150",
                DepositNow = "USD $20.90",
                TaxAndVAT = "USD $19.00",
                TotalAmount = "USD $209.00"
            });
            return testData;
        }
    }
}
