using MasterAPITest.IModels;

namespace MasterAPITest.Models
{
    public class Product : IProduct
    {
        // --- Properties: All must be public  private set; ---
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public byte LanguageType { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
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

        // --- Private Constructor: Only the Builder can call this ---
        private Product(
            long productID, string productName, int stock, string? description, byte languageType, decimal price,
            DateTime? createTime, DateTime? updateTime, bool isActive, bool isDeleted, bool isMedia, bool isTax,
            string? comment, long? productCategoryID, string? unit, decimal purePrice, float? tax,
            long storeID, long storeCategoryID, string? productSaleTag, long creator, long modifier,
            DateTime? activeTimeStart, DateTime? activeTimeEnd, int? level, long? allowList, long? blockList,
            int status)
        {
            ProductID = productID;
            ProductName = productName;
            Stock = stock;
            Description = description;
            LanguageType = languageType;
            Price = price;
            CreateTime = createTime;
            UpdateTime = updateTime;
            IsActive = isActive;
            IsDelete = isDeleted;
            IsMedia = isMedia;
            IsTax = isTax;
            Comment = comment;
            ProductCategoryID = productCategoryID;
            Unit = unit;
            PurePrice = purePrice;
            Tax = tax;
            StoreID = storeID;
            StoreCategoryID = storeCategoryID;
            ProductSaleTag = productSaleTag;
            Creator = creator;
            Modifier = modifier;
            ActiveTimeStart = activeTimeStart;
            ActiveTimeEnd = activeTimeEnd;
            Level = level;
            AllowList = allowList;
            BlockList = blockList;
            Status = status;
        }

        // --- Inner Static Builder Class ---
        public class Builder
        {
            // --- Builder's internal fields for product properties ---
            private long _productID;
            private string _productName;
            private int _stock;
            private string? _description;
            private byte _languageType;
            private decimal _price;
            private DateTime? _createTime;
            private DateTime? _updateTime;
            private bool _isActive;
            private bool _isDeleted;
            private bool _isMedia;
            private bool _isTax;
            private string? _comment;
            private long? _productCategoryID;
            private string? _unit;
            private decimal _purePrice;
            private float? _tax;
            private long _storeID;
            private long _storeCategoryID;
            private string? _productSaleTag;
            private long _creator;
            private long _modifier;
            private DateTime? _activeTimeStart;
            private DateTime? _activeTimeEnd;
            private int? _level;
            private long? _allowList;
            private long? _blockList;
            private int _status;

            public Builder()
            {
                // --- Set default values for properties if needed ---
                _productID = 0; // Or generate a temporary ID if not available at build start
                _productName = "Default Product Name";
                _stock = 0;
                _languageType = 1; // Default to English (example)
                _price = 0.0m;
                _isActive = true; // Default to active
                _isDeleted = false; // Default to not deleted
                _isMedia = false;
                _isTax = false;
                _purePrice = 0.0m;
                _storeID = 0; // You might want to enforce this later
                _storeCategoryID = 0; // You might want to enforce this later
                _creator = 0; // Or another default like a system user ID
                _modifier = 0; // Or another default like a system user ID
                _status = 0; // Default to normal auction
            }

            // --- Fluent Setter Methods: Each returns 'this' (the Builder instance) ---
            public Builder ProductID(long productID) { _productID = productID; return this; }
            public Builder ProductName(string productName) { _productName = productName; return this; }
            public Builder Stock(int stock) { _stock = stock; return this; }
            public Builder Description(string? description) { _description = description; return this; }
            public Builder LanguageType(byte languageType) { _languageType = languageType; return this; }
            public Builder Price(decimal price) { _price = price; return this; }
            public Builder CreateTime(DateTime? createTime) { _createTime = createTime; return this; }
            public Builder UpdateTime(DateTime? updateTime) { _updateTime = updateTime; return this; }
            public Builder IsActive(bool isActive) { _isActive = isActive; return this; }
            public Builder IsDeleted(bool isDeleted) { _isDeleted = isDeleted; return this; }
            public Builder IsMedia(bool isMedia) { _isMedia = isMedia; return this; }
            public Builder IsTax(bool isTax) { _isTax = isTax; return this; }
            public Builder Comment(string? comment) { _comment = comment; return this; }
            public Builder ProductCategoryID(long? productCategoryID) { _productCategoryID = productCategoryID; return this; }
            public Builder Unit(string? unit) { _unit = unit; return this; }
            public Builder PurePrice(decimal purePrice) { _purePrice = purePrice; return this; }
            public Builder Tax(float? tax) { _tax = tax; return this; }
            public Builder StoreID(long storeID) { _storeID = storeID; return this; }
            public Builder StoreCategoryID(long storeCategoryID) { _storeCategoryID = storeCategoryID; return this; }
            public Builder ProductSaleTag(string? productSaleTag) { _productSaleTag = productSaleTag; return this; }
            public Builder Creator(long creator) { _creator = creator; return this; }
            public Builder Modifier(long modifier) { _modifier = modifier; return this; }
            public Builder ActiveTimeStart(DateTime? activeTimeStart) { _activeTimeStart = activeTimeStart; return this; }
            public Builder ActiveTimeEnd(DateTime? activeTimeEnd) { _activeTimeEnd = activeTimeEnd; return this; }
            public Builder Level(int? level) { _level = level; return this; }
            public Builder AllowList(long? allowList) { _allowList = allowList; return this; }
            public Builder BlockList(long? blockList) { _blockList = blockList; return this; }
            public Builder Status(int status) { _status = status; return this; }


            // --- Build Method: Creates and returns the final Product object ---
            public Product Build()
            {
                // --- Validation logic: Essential for ensuring valid objects ---
                if (_productID <= 0)
                {
                    throw new InvalidOperationException("Product ID must be a positive value.");
                }
                if (string.IsNullOrWhiteSpace(_productName))
                {
                    throw new InvalidOperationException("Product name cannot be empty or null.");
                }
                if (_stock < 0)
                {
                    throw new InvalidOperationException("Stock cannot be negative.");
                }
                if (_price < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative.");
                }
                if (_purePrice < 0)
                {
                    throw new InvalidOperationException("Pure price cannot be negative.");
                }
                if (_storeID <= 0)
                {
                    throw new InvalidOperationException("Store ID must be a positive value.");
                }
                if (_storeCategoryID <= 0)
                {
                    throw new InvalidOperationException("Store Category ID must be a positive value.");
                }
                if (_creator <= 0)
                {
                    throw new InvalidOperationException("Creator ID must be a positive value.");
                }
                if (_modifier <= 0)
                {
                    throw new InvalidOperationException("Modifier ID must be a positive value.");
                }

                // You can add more complex validation here, e.g.,
                // - if (IsTax && Tax == null) throw new InvalidOperationException("Tax must be provided if IsTax is true.");
                // - if (ActiveTimeStart != null && ActiveTimeEnd != null && ActiveTimeStart >= ActiveTimeEnd) { /* error */ }

                return new Product(
                    _productID, _productName, _stock, _description, _languageType, _price,
                    _createTime, _updateTime, _isActive, _isDeleted, _isMedia, _isTax,
                    _comment, _productCategoryID, _unit, _purePrice, _tax,
                    _storeID, _storeCategoryID, _productSaleTag, _creator, _modifier,
                    _activeTimeStart, _activeTimeEnd, _level, _allowList, _blockList,
                    _status);
            }
        }
    }
}
