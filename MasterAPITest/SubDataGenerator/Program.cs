using MasterAPITest.DataGenerator;
using MasterAPITest.Models;

var pg = new ProductDataGenerator();
List<Product> ListOfProduct = new List<Product>();
for (int i = 0; i < 10000; i++)
{
    ListOfProduct.Add(pg.ProductDataGenerate());
}





