using Dapper;
using System.Data;

namespace WebApp.Models;
// CategoryRepository kế thừa từ BaseRepository, cung cấp chức năng kết nối
public class SupplierRepository:BaseRepository{
     // Hàm khởi tạo truyền kết nối vào hàm khởi tạo của lớp cơ sở
    public SupplierRepository(IDbConnection cn) : base(cn){
    }
    // Phương thức lấy tất cả các danh mục từ bảng 'Supplier'
    public IEnumerable<Supplier> GetSupplieres(){
        return connection.Query<Supplier>("SELECT * FROM Supplier");
    }

    public Supplier? GetSupplier(string id){
        string sql = "SELECT * FROM Supplier WHERE SupplierId = @id";
        return connection.QuerySingleOrDefault<Supplier>(sql, new{id});
    }

}