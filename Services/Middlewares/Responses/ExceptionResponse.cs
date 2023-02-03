using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Middlewares.Responses
{
    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
