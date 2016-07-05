using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic
{
    public interface ILog
    {
        void Debug(string title);
        void Debug(string title, string detail);

        void Info(string title);
        void Info(string title, string detail);

        void Warn(string title);
        void Warn(string title, string detail);

        void Error(string title);
        void Error(string title, string detail);

        void Fault(string title);
        void Fault(string title, string detail);
    }
}
