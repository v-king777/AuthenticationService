using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public class Logger : ILogger
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public Logger()
        {
            LogDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + 
                DateTime.Now.ToString("dd-MM-yy") + @"/";

            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        private string LogDirectory { get; set; }

        public void WriteEvent(string eventMessage)
        {
            _lock.EnterWriteLock();

            try
            {
                using (var writer = new StreamWriter(LogDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(eventMessage);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }

        }

        public void WriteError(string errorMessage)
        {
            _lock.EnterWriteLock();

            try
            {
                using (var writer = new StreamWriter(LogDirectory + "errors.txt", append: true))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }

        }
    }
}
