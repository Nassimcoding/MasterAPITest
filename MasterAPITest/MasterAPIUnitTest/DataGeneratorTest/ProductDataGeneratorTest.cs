using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterAPITest.DataGenerator;
using MasterAPITest.Models;
using MasterAPITest.Repository;

namespace MasterAPIUnitTest.DataGeneratorTest
{
    public class ProductDataGeneratorTest
    {
        [Fact]
        public void CreateTwoProductAndIDAreDifference()
        {
            var productGenerator = new ProductDataGenerator();
            Product testPud1 = productGenerator.ProductDataGenerate();
            Thread.Sleep(20);// unit test will process together so id will generate some id
            Product testPud2 = productGenerator.ProductDataGenerate();
            Console.WriteLine("testp1");
            Console.WriteLine(testPud1.ProductID);
            Console.WriteLine(testPud1.ProductCategoryID);
            Console.WriteLine(testPud1.StoreID);
            Console.WriteLine(testPud1.StoreCategoryID);

            Console.WriteLine("testp2");
            Console.WriteLine(testPud2.ProductID);
            Console.WriteLine(testPud2.ProductCategoryID);
            Console.WriteLine(testPud2.StoreID);
            Console.WriteLine(testPud2.StoreCategoryID);
            //Assert
            Assert.NotEqual(testPud1.ProductID, testPud2.ProductID);
            Assert.NotEqual(testPud1.ProductCategoryID, testPud2.ProductCategoryID);
            Assert.NotEqual(testPud1.StoreID, testPud2.StoreID);
            Assert.NotEqual(testPud1.StoreCategoryID, testPud2.StoreCategoryID);
        }

        [Fact]
        public void CreateProductIDandProductCategoryIDMustDifference()
        {
            var productGenerator = new ProductDataGenerator();
            Product testPud1 = productGenerator.ProductDataGenerate();
            //Assert
            Assert.NotEqual(testPud1.ProductID, testPud1.ProductCategoryID);
        }

        [Fact]
        public void CreateProductOver10000()
        {
            var productGenerator = new ProductDataGenerator();
            List<Product> ListOfProduct = new List<Product>();
            for (int i = 0; i < 11000; i++)
            {
                ListOfProduct.Add(productGenerator.ProductDataGenerate());
            }

            //Assert
            Assert.True(ListOfProduct.Count > 10000);
        }

        [Fact]
        public void SingleProductInsertToDatabaseTest()
        {
            var productGenerator = new ProductDataGenerator();
            var pDAL = new ProductDAL();
            Product product = productGenerator.ProductDataGenerate();
            

            //Assert
            Assert.True(ListOfProduct.Count > 10000);
        }


    }
}
