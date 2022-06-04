using Entity;

namespace Data;

public class DataContext
{
    private static readonly string[] Cities = new[]
    {
        "Pori", "Tampere", "Helsinki", "Lappeenranta", "Vaasa"
    };
    private readonly List<Invoice> _invoices;
    public DataContext()
    {
        _invoices = new() {
            new() {Id = 1, Date = new DateTime(2021,11,1), DueDate = new DateTime(2021, 12,1), Sum = 100.00m,  Customer = "Cust1"},
            new() {Id = 2, Date = new DateTime(2020,11,1), DueDate = new DateTime(2020, 12,1), Sum = 10.00m,  Customer = "Cust2"},
            new() {Id = 3, Date = new DateTime(2021,1,1), DueDate = new DateTime(2021, 2,1), Sum = 20.00m,  Customer = "Cust3"},
            new() {Id = 4, Date = new DateTime(2021,8,2), DueDate = new DateTime(2021, 10,1), Sum = 50.00m,  Customer = "Cust1"},
            new() {Id = 5, Date = new DateTime(2021,6,12), DueDate = new DateTime(2021, 7,15), Sum = 1000.00m,  Customer = "Cust4"},
            new() {Id = 6, Date = new DateTime(2021,3,10), DueDate = new DateTime(2021, 4,1), Sum = 200.00m,  Customer = "Cust1"},
        };
    }
    public List<Invoice> Invoices => _invoices;
    public List<WeatherForecast> Weather => Enumerable.Range(1, 5)
    .Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            City = Cities[index -1]
        }).ToList();
}