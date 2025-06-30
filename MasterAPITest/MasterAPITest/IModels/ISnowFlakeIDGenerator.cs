namespace MasterAPITest.IModels
{
    public interface ISnowFlakeIDGenerator
    {
        /// <summary>
        /// 產生下一個唯一 ID（long）
        /// </summary>
        long CreateId(ref long se);


    }
}
