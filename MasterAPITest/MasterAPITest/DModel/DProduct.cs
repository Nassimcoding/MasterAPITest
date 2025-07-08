using MasterAPITest.IModels;

namespace MasterAPITest.DModel
{
    public class DProduct : IProduct
    {
        // --- Properties: All must be public  private set; ---
        public long ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string? Description { get; set; }
        public byte LanguageType { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMedia { get; set; }
        public bool IsTax { get; set; }
        public string? Comment { get; set; }
        public long? ProductCategoryID { get; set; }
        public string? Unit { get; set; }
        public decimal PurePrice { get; set; }
        public float? Tax { get; set; }
        public long StoreID { get; set; }
        public long StoreCategoryID { get; set; }
        public string? ProductSaleTag { get; set; }
        public long Creator { get; set; }
        public long Modifier { get; set; }
        public DateTime? ActiveTimeStart { get; set; }
        public DateTime? ActiveTimeEnd { get; set; }
        public int? Level { get; set; }
        public long? AllowList { get; set; }
        public long? BlockList { get; set; }
        public int Status { get; set; }

    }
}
