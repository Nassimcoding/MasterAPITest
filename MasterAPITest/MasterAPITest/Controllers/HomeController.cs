using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MasterAPITest.Repository;
using MasterAPITest.DataGenerator;
using System.Data;

namespace MasterAPITest.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ImplementTest _storePageDAL;
        public HomeController(ImplementTest storePageDAL)
        {
            _storePageDAL = storePageDAL;
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
            string s1 = await _storePageDAL.ttttt(1);
            //_storePageDAL.ttttt(5);
            //_storePageDAL.ttttt(10);
            //_storePageDAL.ttttt(100);
            


            return "success";
        }

    }
}
