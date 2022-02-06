using System;

namespace PersonManagement.Models
{
    public class RequestModel
    {
        public string Ip { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public bool IsSecured { get; set; }
        public DateTime RequestTime => DateTime.Now;
    }
}
