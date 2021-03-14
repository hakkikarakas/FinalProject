using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        // public bool Success => throw new NotImplementedException();
        public bool Success { get; }
        //public string Message => throw new NotImplementedException();
        public string Message { get; }//Get read onlydir Const set edilebilir. Message=message
    }
}
