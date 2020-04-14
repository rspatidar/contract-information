using System;
using System.Collections.Generic;
using System.Text;

namespace EvolentHealth.Core.Model
{
    public class ResponseModel<T> where T:class
    {
        public OrderCreationResultCode ResultCode { get; set; }
        public T Result { get; set; }


    }

   
    public enum OrderCreationResultCode
    {
        Success,
        StockExceeded
    }
}
