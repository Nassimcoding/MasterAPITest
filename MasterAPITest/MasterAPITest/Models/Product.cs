using MasterAPITest.IModels;

namespace MasterAPITest.Models
{
    public class Product : IProduct
    {
        // --- Properties: All must be public with private set; ---
        public long ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public int Stock { get; private set; }
        public string? Description { get; private set; }
        public byte LanguageType { get; private set; }
        public decimal Price { get; private set; }
        public DateTime? CreateTime { get; private set; }
        public DateTime? UpdateTime { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsMedia { get; private set; }
        public bool IsTax { get; private set; }
        public string? Comment { get; private set; }
        public long? ProductCategoryId { get; private set; }
        public string? Unit { get; private set; }
        public decimal PurePrice { get; private set; }
        public float? Tax { get; private set; }
        public long StoreId { get; private set; }
        public long StoreCategoryId { get; private set; }
        public string? ProductSaleTag { get; private set; }
        public long Creator { get; private set; }
        public long Modifier { get; private set; }
        public DateTime? ActiveTimeStart { get; private set; }
        public DateTime? ActiveTimeEnd { get; private set; }
        public int? Level { get; private set; }
        public long? AllowList { get; private set; }
        public long? BlockList { get; private set; }
        public int Status { get; private set; }


    }
}
