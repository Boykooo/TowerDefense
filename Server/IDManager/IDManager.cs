using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.IDManager
{
    public class IDManager
    {
        public IDManager()
        {
            freeID = new Stack<int>();
            count = 0;
        }

        private Stack<int> freeID;
        private int count;

        public int GetID()
        {
            if (freeID.Count != 0)
            {
                return freeID.Pop();
            }
            else
            {
                count++;
                return count;
            }
        }
        public void AddID(int id)
        {
            freeID.Push(id);
        }
    }
}
