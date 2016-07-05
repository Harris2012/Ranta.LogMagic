using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranta.LogMagic.Contract;
using System.ServiceModel;

namespace Ranta.LogMagic
{
    internal class LogSource : ILogSource, IDisposable
    {
        #region 属性
        public int AppId { get; private set; }

        public string SourceClassName { get; private set; }

        LogServiceClient ServiceClient;
        #endregion

        #region 构造函数
        public LogSource()
            : this(string.Empty)
        {
        }

        public LogSource(string sourceClassName)
        {
            this.SourceClassName = sourceClassName;

            var config = RantaConfigManager.GetConfig();

            this.ServiceClient = new LogServiceClient("LogServiceEndpoint");

            if (config != null)
            {
                this.AppId = config.AppId;
            }
        }
        #endregion

        #region ILogSource Members
        public void Write(LogEvent logEvent)
        {
            this.Write(logEvent.Body.Title, logEvent.Body.Detail, logEvent.Header.LogEventType);
        }

        public void Write(string title, LogEventType logEventType)
        {
            this.Write(title, null, logEventType);
        }

        public void Write(string title, string detail, LogEventType logEventType)
        {
            var request = new LogRequest();

            request.Guid = Guid.NewGuid();

            request.LogEvent = new LogEvent();
            request.LogEvent.Header = new LogEventHeader();
            request.LogEvent.Header.AppId = this.AppId;
            request.LogEvent.Header.LogEventType = logEventType;
            request.LogEvent.Header.Source = this.SourceClassName;
            request.LogEvent.Header.CreateTime = DateTime.Now;
            request.LogEvent.Body = new LogEventBody();
            request.LogEvent.Body.Title = title;
            request.LogEvent.Body.Detail = detail;

            LogResponse response = null;

            try
            {
                response = ServiceClient.WriteLog(request);

                //Console.WriteLine(response.Message);
            }
            catch (FaultException<FaultData> fault)
            {
                //Console.WriteLine(fault.Message);

                //Console.WriteLine(fault.Detail.Message);
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.ToString());
            }
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
                    ((IDisposable)ServiceClient).Dispose();
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
