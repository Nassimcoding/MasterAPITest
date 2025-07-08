using MasterAPITest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterAPITest.DataGenerator;
using MasterAPITest.Models;

namespace MasterAPIUnitTest.DataGenerator
{
    public class ProductDataGenerator
    {
        [Fact]
        public void ProductDataGenerate_ReturnsCorrectProductData()
        {
            // Arrange
            var generator = new MasterAPITest.DataGenerator.ProductDataGenerator(); // This will now correctly find the class

            // Act
            Product resultProduct = generator.ProductDataGenerate();

            // Assert
            Assert.NotNull(resultProduct); // 確保 Product 物件不為 null
            Assert.Equal(resultProduct.CreateTime, resultProduct.ModifyTime); // 使用 decimal 字面量 'm'
            Assert.NotEqual(resultProduct.ProductID, resultProduct.ProductCategoryID);
            Assert.NotEqual(resultProduct.StoreID, resultProduct.StoreCategoryID);
        }


    }
}
