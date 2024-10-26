using System.Data;
using Dapper;

namespace WebApp.Models;

public class InvoiceRepository : BaseRepository
{
    public InvoiceRepository(IDbConnection cn) : base(cn)
    {
    }

    public IEnumerable<SalesByAge> GetSalesByAge()
    {
        return connection.Query<SalesByAge>("GetSalesByAge"
        , commandType: CommandType.StoredProcedure);
    }

    public int Add(Invoice obj)
    {
        return connection.Execute("AddInvoice", new
        {
            obj.CartCode,
            obj.InvoiceId,
            obj.InvoiceDate,
            obj.FullName,
            obj.Email,
            obj.Phone,
            obj.Address
        }, commandType: CommandType.StoredProcedure);
    }

    public decimal GetAmountInvoice(long id)
    {
        return connection.ExecuteScalar<decimal>("GetAmountInvoice", new {InvoiceId = id},
        commandType: CommandType.StoredProcedure);
    }
}