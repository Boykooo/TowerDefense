using Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.ClientController.ParseMessage
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
                return formatter.Deserialize(stream) as Message;
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
