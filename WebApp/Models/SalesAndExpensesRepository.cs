using System.Data;
using Dapper;

namespace WebApp.Models;

public class SalesAndExpensesRepository :BaseRepository{
    public SalesAndExpensesRepository(IDbConnection cn): base(cn){ 
    }

    public IEnumerable<SalesAndExpenses> GetSalesAndExpenses()
    {
        return connection.Query<SalesAndExpenses>("SELECT * FROM SalesAndExpenses");
    }
}