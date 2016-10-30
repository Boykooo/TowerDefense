﻿using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IServer 
    {
        void Start();
        void Send(int id, Message msg);

        event Action<int> Connect;
        event Action<int> Disconnect;
        event Action<byte[], int> GetMessage;
    }
}
