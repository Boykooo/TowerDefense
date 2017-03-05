using Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser
    {
        public Parser()
        {
            formatter = new BinaryFormatter();
        }

        private BinaryFormatter formatter;

        public Message GetMessage(byte[] msg)
        {
            using (MemoryStream stream = new MemoryStream(msg))
            {
                object obj = formatter.Deserialize(stream);
                if (obj is Message)
                {
                    return obj as Message;
                }
                else
                {
                    return null;
                }
            }
        }

        public byte[] GetSerializedMessage(Message msg)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, msg);
                return stream.GetBuffer();
            }
        }
    }
}
