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

            // 逐一驗證每個設定的屬性值
            Assert.Equal(1, resultProduct.ProductID);
            Assert.Equal(1, resultProduct.ProductCategoryID); // 注意: 你的 Builder 鏈中 ProductCategoryID 重複了，這通常是沒問題的，因為會被最後一個設定覆蓋。
            Assert.Equal("haha", resultProduct.ProductName);
            Assert.Equal(1, resultProduct.Stock);
            Assert.Equal("123", resultProduct.Description);
            Assert.Equal(1, resultProduct.LanguageType);
            Assert.Equal(50m, resultProduct.Price); // 使用 decimal 字面量 'm'

            // 對於 DateTime.Now，直接比較可能會因為毫秒級差異而失敗，
            // 更好的做法是檢查日期部分，或者在 Builder 中設置一個固定的 DateTime 值用於測試。
            // 這裡我假設你可以接受日期部分近似相等。
            //Assert.Equal(DateTime.Now.Date, resultProduct.CreateTime.Date);
            //Assert.Equal(DateTime.Now.Date, resultProduct.UpdateTime.Date);
            //Assert.Equal(DateTime.Now.Date, resultProduct.ActiveTimeStart.Date);
            //Assert.Equal(DateTime.Now.Date, resultProduct.ActiveTimeEnd.Date);

            Assert.True(resultProduct.IsActive);
            Assert.False(resultProduct.IsDeleted);
            Assert.Equal("", resultProduct.Comment); // 假設 Comment 是一個屬性
            Assert.Equal("stick", resultProduct.Unit); // 假設 Unit 是一個屬性
            Assert.False(resultProduct.IsMedia);
            Assert.Equal(1, resultProduct.Creator);
            Assert.Equal(1, resultProduct.Modifier);
            Assert.False(resultProduct.IsTax);
            Assert.Equal(0.01f, resultProduct.Tax); // 使用 float 字面量 'f'
            Assert.Equal(50m, resultProduct.PurePrice);
            Assert.Equal(1, resultProduct.StoreID);
            Assert.Equal("123:good,234:90%off", resultProduct.ProductSaleTag); // 假設 ProductSaleTag 是一個屬性
            Assert.Equal(50, resultProduct.Level); // 假設 Level 是一個屬性
            Assert.Equal(5, resultProduct.Status);

        }


    }
}
