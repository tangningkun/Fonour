using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Services.AppServices.dto
{
    public class MessageDto
    {
        public int code { get; set; }
        public string message { get; set; }

        public string result { get; set; }

    }

    public class MessageDto<T> : MessageDto
    {
        public T data { get; set; }
    }
}
