using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MasterAPITest.Repository;
using MasterAPITest.DataGenerator;
using System.Data;
using System.Text;

namespace MasterAPITest.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ImplementTest _implementTest;
        public HomeController(ImplementTest implementTest)
        {
            _implementTest = implementTest;
        }
        public async void aaatest()
        {

        }


        [HttpGet("HomeTestAPI")]
        public string HomeTestAPI()
        {



            return "success";
        }


        [HttpPost("HomeTestAPI2")]
        public string HomeTestAPI2()
        {



            return "success";
        }

        [HttpPost("TestProductImplement")]
        public async Task<string> TestProductImplement()
        {
            StringBuilder sb = new StringBuilder();
            //test 1 data
            string s1 = await _implementTest.ProductDALInsertInteTest(1);
            sb.Append("s1 : " + s1);
            
            //test 5 data
            string s2 = await _implementTest.ProductDALInsertInteTest(5);
            sb.Append("s2 : " + s2);

            //_storePageDAL.ttttt(5);
            //_storePageDAL.ttttt(10);
            //_storePageDAL.ttttt(100);


            return sb + "process over";
        }

    }
}
