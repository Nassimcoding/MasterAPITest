using MasterAPITest.IModels;
using System;
using System.Collections.Generic; // 如果 Data 可能是集合，可能需要


namespace MasterAPITest.Models
{

    // 3. 具體實作類別，現在實現介面，並使用 private set 確保不變性
    public class GeneralClass<T> : IApiResponse<T>
    {
        // 將 set 改為 private set，表示屬性只能在建構子內部設定
        public bool IsSuccess { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public int DataCount { get; private set; }
        public string Timestamp { get; private set; }
        public T? Data { get; private set; }
        public string Error { get; private set; }

        // 私有建構子，讓您可以從公共的靜態方法中統一創建物件
        private GeneralClass(bool success, int statusCode, string message, T? data, string? error = null)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Timestamp = DateTime.UtcNow.ToString("o"); // 在建構時設定時間戳
            Error = error ?? "null"; // 如果沒有錯誤訊息，預設為 "null"

            // 自動設定 DataCount
            if (Data is System.Collections.IEnumerable enumerableData && Data is not string) // 避免把 string 當成 enumerable
            {
                DataCount = (Data as dynamic).Count; // 假設集合有 Count 屬性 (例如 List<T>, Array)
            }
            else if (Data != null)
            {
                DataCount = 1; // 如果是單一物件
            }
            else
            {
                DataCount = 0; // 如果 Data 為 null
            }
        }

        // 方便的靜態工廠方法來創建成功的回應
        public static GeneralClass<T> Success(T data, string message = "成功", int statusCode = 200)
        {
            return new GeneralClass<T>(true, statusCode, message, data);
        }
        

        // 方便的靜態工廠方法來創建失敗的回應
        public static GeneralClass<T> Failure(string message = "操作失敗", int statusCode = 400, string? error = null)
        {
            // 失敗時 Data 通常為 null
            return new GeneralClass<T>(false, statusCode, message, default, error);
        }

    }

}
