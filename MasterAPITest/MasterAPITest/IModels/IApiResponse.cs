namespace MasterAPITest.IModels
{
    public interface IApiResponse
    {
        // 這些屬性代表 API 回應的基本狀態和元數據
        bool IsSuccess { get; }
        int StatusCode { get; }
        string Message { get; }
        string Timestamp { get; } // 通常是回傳的時間
        string Error { get; }     // 如果有錯誤，這裡會包含錯誤訊息
    }

    // 2. 定義帶有泛型資料的 API 回傳介面 (包含業務資料和資料筆數)
    public interface IApiResponse<T> : IApiResponse
    {
        // DataCount 表示 Data 集合中的項目數量，如果 Data 是單一物件，則為 1 或 0
        int DataCount { get; }
        // 實際的業務資料，可以是單一物件或集合
        T? Data { get; }
    }
}

