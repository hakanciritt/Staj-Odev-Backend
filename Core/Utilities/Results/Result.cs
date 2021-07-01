using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public string Message { get; }

        public bool Success { get; }

        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success,string message):this(success)
        {
            Success = success;
            Message = message;
        }
    }
}
