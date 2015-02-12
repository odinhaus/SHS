using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHS.Models
{
    public enum ResponseType
    {
        Success = 0,
        Failure
    }
    public class ActionResponse
    {
        public ResponseType ResponseType { get; set; }
        public string RedirectUri { get; set; }
        public string Message { get; set; }

        public static implicit operator ActionResponse(string redirectUri)
        {
            return new ActionResponse(){ ResponseType = ResponseType.Success, Message = "Success", RedirectUri= redirectUri };
        }
    }
}