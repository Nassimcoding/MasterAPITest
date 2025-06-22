using Dapper;
using MasterAPITest.DModel;
using MasterAPITest.IModels;
using MasterAPITest.IRepository;
using MasterAPITest.Models;
using Microsoft.OpenApi.Any;
using System.Data;

namespace MasterAPITest.Repository
{
    public class ProductDAL : IDAL<Product,DProduct>
    {
        private readonly IDbConnection con;
        public ProductDAL(IDbConnection Con)
        {
            con = Con;
        }
        public async Task<bool> Insert(List<Product> products)
        {
            string sql = @"
INSERT INTO Product
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
    IsDelete,
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
    @IsDelete,
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
            int ch = 0;
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    ch += await con.ExecuteAsync(sql, products[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Insert Error:");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            return ch == products.Count;

        }

        public async Task<List<DProduct>> GetALL()
        {
            string sql = @"
SELECT * FROM Product";
            IEnumerable<DProduct> products = await con.QueryAsync<DProduct>(sql);
            return products.ToList();
        }

        public async Task<DProduct> GetByID(long productID)
        {
            string sql = @"
SELECT * 
FROM Product
WHERE ProductID = @id";
            var product = await con.QueryFirstOrDefaultAsync<DProduct>(sql, new { id = productID });
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
        }
        public async Task<List<DProduct>> GetBySearchKeyword(string searchKeyword)
        {
            string sql = @"
SELECT * 
FROM Product 
WHERE 
ProductName LIKE @skw1 
OR Descroption LIKE @skw2
OR Comment LIKE @skw3
";
            IEnumerable<DProduct> products = await con.QueryAsync<DProduct>(sql,
                new
                {
                    skw1 = "%" + searchKeyword + "%",
                    skw2 = "%" + searchKeyword + "%",
                    skw3 = "%" + searchKeyword + "%"
                });

            return products.AsList();
        }
        public async Task<bool> UpdateByID(Product product, long modifierID)
        {

            string sql = @"
UPDATE Product
SET
    ProductName = @ProductName,
    Stock = @Stock,
    Description = @Description,
    LanguageType = @LanguageType,
    Price = @Price,
    UpdateTime = @UpdateTime,      
    IsActive = @IsActive,
    IsDelete = @IsDelete,
    IsMedia = @IsMedia,
    IsTax = @IsTax,
    Comment = @Comment,
    ProductCategoryID = @ProductCategoryID,
    Unit = @Unit,
    PurePrice = @PurePrice,
    Tax = @Tax,
    ProductSaleTag = @ProductSaleTag,
    Modifier = @Modifier,           
    ActiveTimeStart = @ActiveTimeStart,
    ActiveTimeEnd = @ActiveTimeEnd,
    Level = @Level,
    AllowList = @AllowList,
    BlockList = @BlockList,
    Status = @Status
WHERE ProductID = @ProductID;";

            //product.UpdateTime; DateTime.Now);
            //product.Modifier = modifierId;

            int rowsAffected = await con.ExecuteAsync(sql, product);
            return rowsAffected == 1;
        }

        public async Task<bool> DeleteByID(long productID, long modifierID)
        {
            string sql = @"
UPDATE Product
SET
IsDelete = @IsDelete,
IsActive = @IsActive, // Often also set to false when soft deleted
UpdateTime = @UpdateTime,
Modifier = @Modifier
WHERE ProductID = @ProductID;";

            var parameters = new
            {
                ProductID = productID,
                IsDeleted = true,
                IsActive = false,
                UpdateTime = DateTime.Now,
                Modifier = modifierID
            };

            int rowsAffected = await con.ExecuteAsync(sql, parameters);
            return rowsAffected == 1;
        }
    }
}
