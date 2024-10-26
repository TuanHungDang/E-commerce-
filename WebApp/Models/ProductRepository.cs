using System.Data;
using Dapper;

namespace WebApp.Models;

public class ProductReposirory : BaseRepository
{
    public ProductReposirory(IDbConnection cn) : base(cn){
    }

    public IEnumerable<Product> GetProducts(){
        return connection.Query<Product>("SELECT * FROM Product");
    }

    public IEnumerable<Product> GetProductsByCategory(short id){
        string sql = "SELECT * FROM Product WHERE Categoryid = @Id";
        return connection.Query<Product>(sql, new{id});
    }

    public Product? GetProduct(int id){
        string sql = "SELECT * FROM Product WHERE ProductId = @Id";
        return connection.QuerySingleOrDefault<Product>(sql, new{id});
    }

    public IEnumerable<Product> GetProductsRelation(short Categoryid, int id )
    {
        string sql = " SELECT * FROM Product WHERE CategoryId = @CategoryId AND ProductId <> @id";
        return connection.Query<Product>(sql, new{Categoryid, id});
    }
}