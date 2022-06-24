using EventCommon;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OrderDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("PayOrder")]
        public async Task<IActionResult> PayOrder([FromServices] IPublishEndpoint publishEndpoint)
        {
            bool isPay = false;

            // 模拟支付成功
            isPay = true;

            if (isPay)
            {
                await publishEndpoint.Publish(new OrderPaySuccessEvent
                {
                    OrderNo = "Test Order No1",
                    PayDateTime = DateTime.Now
                });
            }

            return Ok("订单支付成功!!!");
        }
    }
}
