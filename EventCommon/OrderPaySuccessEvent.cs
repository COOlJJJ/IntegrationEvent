using System;

namespace EventCommon
{
    public class OrderPaySuccessEvent
    {
        //订单号
        public string OrderNo { get; set; }
        //支付时间
        public DateTime PayDateTime { get; set; }
    }
}
