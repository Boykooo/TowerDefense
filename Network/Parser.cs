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

                return obj as Message;
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
