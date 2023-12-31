﻿using Microsoft.AspNetCore.Mvc;
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

            return quickFixService_.InitiateProcessToSendOrder(order);
           
        }
    }
}
