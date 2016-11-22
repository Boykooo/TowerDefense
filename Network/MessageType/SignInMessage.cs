using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network
{
    public class SignInMessage : Message
    {
        public SignInMessage(string login, string password) : base("SignIn", login, password)
        {   

        }
    }
}
