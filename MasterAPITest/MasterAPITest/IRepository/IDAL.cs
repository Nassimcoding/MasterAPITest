using System.Runtime.InteropServices;

namespace MasterAPITest.IRepository
{
    public interface IDAL<T> where T : class
    {
        public Task<bool> Insert(List<T> entity);
        public Task<List<T>> GetALL();
        public Task<T> GetByID(long id);
        public Task<List<T>> GetBySearchKeyword(string searchKeyword);
        public Task<bool> UpdateByID(T entity,long modifyID);
        public Task<bool> DeleteByID(long id, long modifyID);
    }
}
