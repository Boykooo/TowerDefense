using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Network
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
