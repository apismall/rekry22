using Microsoft.AspNetCore.Mvc;
using Entity;
using Data;
using Dto;

namespace rekry.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<InvoiceController> _logger;
    private readonly DataContext _dataContext;

    public InvoiceController(ILogger<InvoiceController> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    [HttpGet("get/{id}")]
    public Entity.Invoice Index(int id)
    {
        try
        {
            return _dataContext.Invoices.Single(invoice => invoice.Id == id);
        }
        catch (System.InvalidOperationException)
        {
            return new Entity.Invoice();
        }

    }

    [HttpGet("list/")]
    public List<Entity.Invoice> list(bool paid = false, string? customerName = "")
    {
        var filtered = _dataContext.Invoices.ToList();
        if (paid)
        {
            filtered.RemoveAll(invoice => invoice.Sum != 0.0m);
        }

        if (customerName != "")
        {
            filtered.RemoveAll(invoice => invoice.Customer != customerName);
        }
        return filtered;
    }
}
