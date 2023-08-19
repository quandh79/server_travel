using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_travel.Dtos
{
    public class PagingRequestBase
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
