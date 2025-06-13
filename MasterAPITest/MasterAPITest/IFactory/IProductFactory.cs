using MasterAPITest.IModels;
using MasterAPITest.Models;

namespace MasterAPITest.IFactory
{
    public interface IProductFactory
    {

        //// --- Create Methods (使用 Builder) ---
        //// 提供一個 Builder 實例，讓使用者自行組裝產品
        //Product.Builder CreateProductBuilder();
        //// 快速創建一個隨機產品 (用於假資料或測試)
        //IProduct CreateRandomProduct();
        //// 快速創建一個預設產品 (用於基本產品創建)
        //IProduct CreateDefaultProduct(long storeId, long creatorId);

        //// --- Read Methods ---
        //IProduct? GetProductById(long productId);
        //IEnumerable<IProduct> GetAllProducts();
        //IEnumerable<IProduct> GetActiveProducts();
        //IEnumerable<IProduct> GetDeletedProducts();


        //// --- Update Methods ---
        //// 更新產品資訊，通常需要傳入一個新的 Product 物件或部分更新的資料
        //// 這裡我們讓 Factory 處理更新邏輯，返回更新後的產品
        //IProduct UpdateProduct(IProduct productToUpdate);
        //// 啟用/禁用產品
        //IProduct SetProductActiveStatus(long productId, bool isActive);


        //// --- Delete Methods (假刪除) ---
        //// 執行假刪除：將 IsDeleted 設為 true
        //IProduct SoftDeleteProduct(long productId, long modifierId);
        //// 恢復假刪除：將 IsDeleted 設為 false
        //IProduct RestoreProduct(long productId, long modifierId);

        // --- Hard Delete (實際刪除，如果需要的話) ---
        // 注意：實際刪除通常會被嚴格控制，可能不直接暴露在 Factory 介面中，
        // 或只供特定管理員角色使用。
        // void HardDeleteProduct(long productId);
    }
}

