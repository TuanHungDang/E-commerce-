namespace WebApp.Models;

public class Product{
    public short ProductId{get; set;}
    public string ProductName{get; set;} = null!;
    public string ProductAlias{get; set;} = null!;
    public short CategoryId{get; set;}
    public string Unit{get; set;} = null!;
    public decimal Price{get; set;}
    public string Image{get; set;} = null!;
    public DateTime ProductDate{get; set;}
    public decimal SaleOff{get; set;}
    public int Viewed{get; set;}
    public string Description{get; set;} = null!;
    public string SupplierId{get; set;} = null!;

}

/*CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductName] [nvarchar](64) NOT NULL,
	[ProductAlias] [nvarchar](64) NULL,
	[CategoryId] SMALLINT NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [DECIMAL] NULL,
	[Image] [nvarchar](50) NULL,
	[ProductDate] [datetime] NOT NULL,
	[SaleOff] [DECIMAL] NOT NULL,
	[Viewed] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SupplierId] [varchar](2) NOT NULL
);*/