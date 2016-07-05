using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranta.LogMagic.Contract;

namespace Ranta.LogMagic
{
    internal interface ILogSource
    {
        void Write(LogEvent logEvent);

        void Write(string title, LogEventType logEventType);

        void Write(string title, string detail, LogEventType logEventType);
    }
}
