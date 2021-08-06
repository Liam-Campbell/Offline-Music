using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiamsMusic
{
    static public class SingleInstance
    {       
        static Mutex mutex;
        static public bool Start()
        {
            bool onlyInstance = false;
            string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);
            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }
        static public void Stop()
        {
            mutex.ReleaseMutex();
        }
    }
}
