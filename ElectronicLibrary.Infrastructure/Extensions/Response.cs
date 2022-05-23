using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public class Response<T>
    {
        public T Result { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }

    }
}
