namespace MasterAPITest.IModels
{
    public interface IProduct
    {

        // Primary Key
        long ProductID { get; set; } // BIGINT NOT NULL PRIMARY KEY -- Snowflake generated

        // Core Product Information
        string ProductName { get; set; } // NVARCHAR(200) NOT NULL
        int Stock { get; set; } // INT NOT NULL
        string? Description { get; set; } // NVARCHAR(MAX) NULL (nullable string)
        byte LanguageType { get; set; } // TINYINT NOT NULL (e.g., 2 = en, 1 = tw, 3 = jp)
        decimal Price { get; set; } // DECIMAL(12, 3) NOT NULL (using decimal for precision)

        // Timestamps
        DateTime? CreateTime { get; set; } // DATETIME NULL (nullable DateTime)
        DateTime? ModifyTime { get; set; } // DATETIME NULL (nullable DateTime)

        // Status Flags
        bool IsActive { get; set; } // BIT NOT NULL DEFAULT 1 (true for active)
        bool IsDelete { get; set; } // BIT NOT NULL DEFAULT 0 (true for soft deleted)
        bool IsMedia { get; set; } // BIT NOT NULL DEFAULT 0 (true if has product media data)
        bool IsTax { get; set; } // BIT NOT NULL DEFAULT 0 (true if tax applies)

        // Additional Product Details
        string? Comment { get; set; } // NVARCHAR(200) NULL (nullable string)
        long? ProductCategoryID { get; set; } // BIGINT NULL (FK to Category ID table)
        string? Unit { get; set; } // NVARCHAR(10) NULL (item measurement unit)
        decimal PurePrice { get; set; } // DECIMAL(12, 3) NOT NULL (original price after tax removal)
        float? Tax { get; set; } // FLOAT NULL (nullable float for tax rate)

        // Store and Sales Information
        long StoreID { get; set; } // BIGINT NOT NULL (which store the product belongs to)
        long StoreCategoryID { get; set; } // BIGINT NOT NULL (product category within the store)
        string? ProductSaleTag { get; set; } // NVARCHAR(MAX) NULL (e.g., #85折, #買一送一)

        // Creators and Modifiers
        long Creator { get; set; } // BIGINT NOT NULL
        long Modifier { get; set; } // BIGINT NOT NULL

        // Active Time Control
        DateTime? ActiveTimeStart { get; set; } // DATETIME NULL (active from this time, overrides IsActive)
        DateTime? ActiveTimeEnd { get; set; } // DATETIME NULL (active until this time, overrides IsActive)

        // Access Control and Status
        int? Level { get; set; } // INT NULL (null for anyone, or min level required)
        long? AllowList { get; set; } // BIGINT NULL (FK to allowlist.allowlistid)
        long? BlockList { get; set; } // BIGINT NULL (FK to blocklist.blockid)
        int Status { get; set; } // INT NOT NULL (0=normal, 1=out of stock, 2=discontinued, etc.)



    }
}
