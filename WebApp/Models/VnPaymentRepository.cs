using System.Data;
using Dapper;
using WebApp.Services;

namespace WebApp.Models;

public class VnPaymentRepository : BaseRepository
{
    public VnPaymentRepository(IDbConnection connection) : base(connection){}

    public int Add(VnPaymentResponse obj){
        return connection.Execute("AddVnPayment", obj,commandType: CommandType.StoredProcedure);
    }
}