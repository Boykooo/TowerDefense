using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    [Serializable]
    public class Message
    {
        public Message(string method, params object[] args)
        {
            Method = method;
            Arguments = args;
        }

        public string Method { get; }
        public object[] Arguments { get; }
    }
}
