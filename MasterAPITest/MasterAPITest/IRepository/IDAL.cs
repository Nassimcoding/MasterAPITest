using System.Runtime.InteropServices;

namespace MasterAPITest.IRepository
{
    public interface IDAL
    {
        public bool Insert();
        public object GetALL();
        public object GetByID();
        public object GetBySearchKeyword();
        public bool UpdateByID();
        public bool DeleteByID();





    }
}
