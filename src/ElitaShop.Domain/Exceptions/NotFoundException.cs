using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string TitleMessage { get; set; } = string.Empty;
    }
}
