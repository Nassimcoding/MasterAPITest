using System.Runtime.InteropServices;

namespace MasterAPITest.IRepository
{
    public interface IDAL<InputT,OutputT> 
        where InputT : class
        where OutputT : class
    {
        public Task<bool> Insert(List<InputT> entity);
        public Task<List<OutputT>> GetALL();
        public Task<OutputT> GetByID(long id);
        public Task<List<OutputT>> GetBySearchKeyword(string searchKeyword);
        public Task<bool> UpdateByID(InputT entity,long modifyID);
        public Task<bool> DeleteByID(long id, long modifyID);
    }
}
