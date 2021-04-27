using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.Common.Models
{
    public class Paginator
    {
        public int? PageSize { get; set; }

        public string OffsetId { get; set; }
    }
}
