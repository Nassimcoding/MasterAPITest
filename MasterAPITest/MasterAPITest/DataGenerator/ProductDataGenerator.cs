using MasterAPITest.Models;

namespace MasterAPITest.DataGenerator
{
    public class ProductDataGenerator : IDataGenerator
    {
        public Product ProductDataGenerate() {

            return new Product.Builder()
                .ProductID(1)
                .ProductCategoryID(1)
                .ProductName("haha")
                .Stock(1)
                .Description("123")
                .LanguageType(1)
                .Price(50)
                .CreateTime(DateTime.Now)
                .UpdateTime(DateTime.Now)
                .IsActive(true)
                .IsDeleted(false)
                .Comment("")
                .ProductCategoryID(1)
                .Unit("stick")
                .IsMedia(false)
                .Creator(1)
                .Modifier(1)
                .IsTax(false)
                .Tax(0.01f)
                .PurePrice(50)
                .StoreID(1)
                .StoreCategoryID(1)
                .ProductSaleTag("123:good,234:90%off")
                .ActiveTimeStart(DateTime.Now)
                .ActiveTimeEnd(DateTime.Now)
                .Level(50)
                .Status(5)
                .Build();
        }


    }
}
