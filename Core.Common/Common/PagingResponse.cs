using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common
{
    public class PagingResponse
    {
        public object PageData { get; set; }
        public int Total { get; set; }

        public PagingResponse(object data, int total)
        {
            this.PageData = data;
            this.Total = total;
        }
    }
}
