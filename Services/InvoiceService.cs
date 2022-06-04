using Data;

namespace Services;

public class InvoiceService : IInvoiceService
{
    private readonly DataContext _data;
    public InvoiceService(DataContext data)
    {
        _data = data;
    }
    public void PayInvoice(int invoiceId)
    {
        var invoice = _data.Invoices.Where(x => x.Id == invoiceId).FirstOrDefault();
        if (invoice != null)
            invoice.Sum = 0.0m;
    }
}