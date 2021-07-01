using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CoreProject.Models.Responses
{
    public class ResponseData
    {
        public HttpStatusCode Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseData()
        {
            Code = HttpStatusCode.OK;
            Data = null;

        }

    }
}
