using System.Data;
using Dapper;

namespace WebApp.Models;

public class EmployeeRepository : BaseRepository
{
    public EmployeeRepository(IDbConnection cn) : base(cn)
    {}

    public IEnumerable<Employee> GetEmployeesAndParent()
    {
        return connection.Query<Employee>("GetEmployeesAndParent",
        commandType: CommandType.StoredProcedure);
    }
}