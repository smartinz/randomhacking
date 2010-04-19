using System;
using System.Runtime.Serialization;

namespace SpikeWcf.WcfHelpers
{
    [DataContract]
    public class ExceptionInfo
    {
        public ExceptionInfo(Exception e)
        {
            Message = e.Message;
        }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}