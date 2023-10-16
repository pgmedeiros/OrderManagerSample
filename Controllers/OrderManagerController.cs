using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.QuickFixClass;

namespace OrderApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderManagerController : ControllerBase
    {

        private readonly QuickFixService quickFixService_;

        public OrderManagerController(QuickFixService quickFixService)
        {
            quickFixService_ = quickFixService;
        }

        [HttpPost]
        [Route("create_order")]
        public string CreateOrder(Order order)
        {

            if (!isInvalid(order))
            {
                string retorno = quickFixService_.SendOrder(order);
                quickFixService_.Logout();
                return retorno;
            } else
            {
                return "A quantidade deve ser maior que zero.";
            }
          
        }

        private bool isInvalid(Order order)
        {
            return (order.qty <= 0);
          
        }
      
    }
}
