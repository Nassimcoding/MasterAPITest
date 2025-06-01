using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterAPITest.Controllers
{
    public class HomeController : ControllerBase
    {
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
    }
}
