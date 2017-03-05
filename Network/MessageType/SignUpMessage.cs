using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network.MessageType
{
    [Serializable]
    public class SignUpMessage : Message
    {
        public SignUpMessage(string login, string password, string mail) : base("SignUp", login, password, mail)
        {
        }
    }
}
