using Dapper;
using MasterAPITest.IRepository;
using MasterAPITest.Models;
using System.Data;

namespace MasterAPITest.Repository
{
    public class ProductDAL : IDAL
    {
        private readonly IDbConnection con;
        public ProductDAL(IDbConnection Con)
        {
            con = Con;
        }
        public async Task<bool> Insert(List<Product> products)
        {
            string sql = @"
INSERT INTO Products
(
    ProductID,
    ProductName,
    Stock,
    Description,
    LanguageType,
    Price,
    CreateTime,
    UpdateTime,
    IsActive,
    IsDeleted,
    IsMedia,
    IsTax,
    Comment,
    ProductCategoryID,
    Unit,
    PurePrice,
    Tax,
    StoreID,
    StoreCategoryID,
    ProductSaleTag,
    Creator,
    Modifier,
    ActiveTimeStart,
    ActiveTimeEnd,
    Level,
    AllowList,
    BlockList,
    Status
)
VALUES
(
    @ProductID,
    @ProductName,
    @Stock,
    @Description,
    @LanguageType,
    @Price,
    @CreateTime,
    @UpdateTime,
    @IsActive,
    @IsDeleted,
    @IsMedia,
    @IsTax,
    @Comment,
    @ProductCategoryID,
    @Unit,
    @PurePrice,
    @Tax,
    @StoreID,
    @StoreCategoryID,
    @ProductSaleTag,
    @Creator,
    @Modifier,
    @ActiveTimeStart,
    @ActiveTimeEnd,
    @Level,
    @AllowList,
    @BlockList,
    @Status
);";
            int checkNums = await con.ExecuteAsync(sql, products);
            return checkNums == products.Count;

        }
        public object GetALL();
        public object GetByID();
        public object GetBySearchKeyword();
        public bool UpdateByID();
        public bool DeleteByID();



    }
}
