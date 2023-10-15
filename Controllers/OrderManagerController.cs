using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.QuickFixClass;

namespace OrderApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderManagerController : ControllerBase
    {

        QuickFixService q = null;

        [HttpGet]
        [Route("Josefo")]
        public string CreateOrder()
        {
            q = new QuickFixService();
           
            q.Do();
            q.Logout();

            return "ok";    
        }
      
    }
}
