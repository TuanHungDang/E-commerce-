namespace WebApp.Models;
public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration conf) : base(conf)
    {
    }
    CategoryRepository? category;
    public CategoryRepository Category => category ??= new(Connection);


    ProductReposirory product;
    public ProductReposirory Product => product ??= new(Connection);


    SupplierRepository supplier;
    public SupplierRepository Supplier => supplier ??= new(Connection);

    CartRepository cart;
    public CartRepository Cart => cart ??= new(Connection);

    InvoiceRepository? invoice;
    public InvoiceRepository Invoice => invoice ??= new(Connection);

    EmployeeRepository employee;
    public EmployeeRepository Employee => employee ??= new(Connection);

    SalesAndExpensesRepository salesAndExpenses;
    public SalesAndExpensesRepository SalesAndExpenses => salesAndExpenses ??= new(Connection);

    VnPaymentRepository vnPayment;
    public VnPaymentRepository VnPayment => vnPayment ??= new(Connection);
}