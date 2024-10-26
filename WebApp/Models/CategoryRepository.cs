using Dapper;
using System.Data;

namespace WebApp.Models;
// CategoryRepository kế thừa từ BaseRepository, cung cấp chức năng kết nối
public class CategoryRepository:BaseRepository{
     // Hàm khởi tạo truyền kết nối vào hàm khởi tạo của lớp cơ sở
    public CategoryRepository(IDbConnection cn) : base(cn){
    }

    public IEnumerable<CategoryProduct> GetCategoryAndProducts()
    {
        return connection.Query<CategoryProduct>("GetCategoryAndProducts", 
        commandType: CommandType.StoredProcedure);
    }


    // Phương thức lấy tất cả các danh mục từ bảng 'Category'
    public IEnumerable<Category> GetCategories(){
        return connection.Query<Category>("Select * from Category");
    }

    public Category? GetCategory(short id){
        string sql = "SELECT * FROM Category WHERE CategoryId = @id";
        return connection.QuerySingleOrDefault<Category>(sql, new{id});
    }
    

}