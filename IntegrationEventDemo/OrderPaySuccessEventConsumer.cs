using EventCommon;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ExpressDemo
{
    public class OrderPaySuccessEventConsumer : IConsumer<OrderPaySuccessEvent>
    {
        /// <summary>
        /// 实现接口处理业务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Consume(ConsumeContext<OrderPaySuccessEvent> context)
        {
            Console.WriteLine($"物流模块订阅到事件,正在处理{context.Message.OrderNo}");

            return Task.CompletedTask;
        }
    }
}
