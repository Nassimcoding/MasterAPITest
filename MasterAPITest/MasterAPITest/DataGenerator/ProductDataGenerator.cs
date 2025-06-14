using MasterAPITest.Models;

namespace MasterAPITest.DataGenerator
{
    public class ProductDataGenerator : IDataGenerator
    {
        public Product ProductDataGenerate() {
            Random rand = new Random();
            var genID = new SnowFlakeIDGenerator(machineId: 2);
            long productID = genID.CreateId();
            long productCategoryID = genID.CreateId();
            string productName = "TestProductName";
            int stock = rand.Next(0, 1200);
            string descroption = "Test Description content";
            byte languageType = 1;
            decimal productPrice = rand.Next(1, 80000);
            var systemTimeNow = DateTime.Now;
            bool isActive = rand.Next(0,2) == 1;
            bool isDeleted = rand.Next(0, 2) == 1;
            string comment = "here say something product arrive about 15 day " +
                "because typhone comming and all shipment will delate.";
            string unit = rand.Next(0, 1) == 1 ? "Box" : "Bundle";
            bool isMedia = false;
            long creator = genID.CreateId();
            long modifier = genID.CreateId();
            bool isTax = false;
            float tax = 0.0f;
            decimal purePrice = productPrice;
            long storeID = genID.CreateId();
            long storeCategoryID = genID.CreateId();
            string productSaleTag = @"[
  {
                ""ID"": 111,
    ""SALENAME"": ""買一送一""
  },
  {
                ""ID"": 100,
    ""SALENAME"": ""95折""
  },
  {
                ""ID"": 98,
    ""SALENAME"": ""文學展特賣""
  }
]";
            int level = rand.Next(1, 201);
            int status = rand.Next(0, 6);

            return new Product.Builder()
                .ProductID(genID.CreateId())
                .ProductCategoryID(genID.CreateId())
                .ProductName(productName)
                .Stock(stock)
                .Description(descroption)
                .LanguageType(languageType)
                .Price(productPrice)
                .CreateTime(systemTimeNow)
                .UpdateTime(systemTimeNow)
                .IsActive(isActive)
                .IsDeleted(isDeleted)
                .Comment(comment)
                .Unit(unit)
                .IsMedia(isMedia)
                .Creator(genID.CreateId())
                .Modifier(genID.CreateId())
                .IsTax(isTax)
                .Tax(tax)
                .PurePrice(purePrice)
                .StoreID(storeID)
                .StoreCategoryID(storeCategoryID)
                .ProductSaleTag(productSaleTag)
                .ActiveTimeStart(systemTimeNow)
                .ActiveTimeEnd(systemTimeNow)
                .Level(level)
                .Status(status)
                .Build();
        }


    }
}
