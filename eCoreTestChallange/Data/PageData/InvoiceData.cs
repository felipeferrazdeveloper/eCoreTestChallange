using System.Data;

namespace eCoreTestChallenge.Data.PageData;

public record InvoiceData : LoginData
{        
    public string? HotelName { get; private init; }
    public string? InvoiceDate { get; private init; }
    public string? DueDate { get; private init; }
    public string? InvoiceNumber { get; private init; }
    public string? BookingCode { get; private init; }
    public string? CustomerDetails { get; private init; }
    public string? Room { get; private init; }
    public string? CheckIn { get; private init; }
    public string? CheckOut { get; private init; }
    public string? TotalStayCount { get; private init; }
    public string? TotalStayAmount { get; private init; }
    public string? DepositNow { get; private init; }
    public string? TaxAndVat { get; private init; }
    public string? TotalAmount { get; private init; }

    public static DataTable SampleInvoiceTestData()
    {
        _testData = new DataTable();
        _testData.Columns.Add("Data", typeof(InvoiceData));
        _testData.Rows.Add(new InvoiceData
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
            TaxAndVat = "USD $19.00",
            TotalAmount = "USD $209.00"
        });
        return _testData;
    }
}