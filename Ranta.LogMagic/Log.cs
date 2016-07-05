using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranta.LogMagic.Contract;

namespace Ranta.LogMagic
{
    internal class Log : ILog, IDisposable
    {
        private ILogSource logSource = null;

        #region 构造函数
        public Log()
        {
            this.logSource = new LogSource();
        }

        public Log(string source)
        {
            this.logSource = new LogSource(source);
        }
        #endregion

        #region ILogger Members
        public void Debug(string title)
        {
            this.logSource.Write(title, LogEventType.Debug);
        }

        public void Debug(string title, string detail)
        {
            this.logSource.Write(title, detail, LogEventType.Debug);
        }

        public void Info(string title)
        {
            this.logSource.Write(title, LogEventType.Info);
        }

        public void Info(string title, string detail)
        {
            this.logSource.Write(title, detail, LogEventType.Info);
        }

        public void Warn(string title)
        {
            this.logSource.Write(title, LogEventType.Warn);
        }

        public void Warn(string title, string detail)
        {
            this.logSource.Write(title, detail, LogEventType.Warn);
        }

        public void Error(string title)
        {
            this.logSource.Write(title, LogEventType.Error);
        }

        public void Error(string title, string detail)
        {
            this.logSource.Write(title, detail, LogEventType.Error);
        }

        public void Fault(string title)
        {
            this.logSource.Write(title, LogEventType.Fault);
        }

        public void Fault(string title, string detail)
        {
            this.logSource.Write(title, detail, LogEventType.Fault);
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ((IDisposable)logSource).Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
