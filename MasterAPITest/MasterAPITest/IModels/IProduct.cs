namespace MasterAPITest.IModels
{
    public interface IProduct
    {

        // Primary Key
        long ProductID { get; } // BIGINT NOT NULL PRIMARY KEY -- Snowflake generated

        // Core Product Information
        string ProductName { get; } // NVARCHAR(200) NOT NULL
        int Stock { get; } // INT NOT NULL
        string? Description { get; } // NVARCHAR(MAX) NULL (nullable string)
        byte LanguageType { get; } // TINYINT NOT NULL (e.g., 2 = en, 1 = tw, 3 = jp)
        decimal Price { get; } // DECIMAL(12, 3) NOT NULL (using decimal for precision)

        // Timestamps
        DateTime? CreateTime { get; } // DATETIME NULL (nullable DateTime)
        DateTime? UpdateTime { get; } // DATETIME NULL (nullable DateTime)

        // Status Flags
        bool IsActive { get; } // BIT NOT NULL DEFAULT 1 (true for active)
        bool IsDeleted { get; } // BIT NOT NULL DEFAULT 0 (true for soft deleted)
        bool IsMedia { get; } // BIT NOT NULL DEFAULT 0 (true if has product media data)
        bool IsTax { get; } // BIT NOT NULL DEFAULT 0 (true if tax applies)

        // Additional Product Details
        string? Comment { get; } // NVARCHAR(200) NULL (nullable string)
        long? ProductCategoryID { get; } // BIGINT NULL (FK to Category ID table)
        string? Unit { get; } // NVARCHAR(10) NULL (item measurement unit)
        decimal PurePrice { get; } // DECIMAL(12, 3) NOT NULL (original price after tax removal)
        float? Tax { get; } // FLOAT NULL (nullable float for tax rate)

        // Store and Sales Information
        long StoreID { get; } // BIGINT NOT NULL (which store the product belongs to)
        long StoreCategoryID { get; } // BIGINT NOT NULL (product category within the store)
        string? ProductSaleTag { get; } // NVARCHAR(MAX) NULL (e.g., #85折, #買一送一)

        // Creators and Modifiers
        long Creator { get; } // BIGINT NOT NULL
        long Modifier { get; } // BIGINT NOT NULL

        // Active Time Control
        DateTime? ActiveTimeStart { get; } // DATETIME NULL (active from this time, overrides IsActive)
        DateTime? ActiveTimeEnd { get; } // DATETIME NULL (active until this time, overrides IsActive)

        // Access Control and Status
        int? Level { get; } // INT NULL (null for anyone, or min level required)
        long? AllowList { get; } // BIGINT NULL (FK to allowlist.allowlistid)
        long? BlockList { get; } // BIGINT NULL (FK to blocklist.blockid)
        int Status { get; } // INT NOT NULL (0=normal, 1=out of stock, 2=discontinued, etc.)



    }
}
