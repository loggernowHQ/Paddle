using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggernow.Paddle.Utils
{
    /// <summary>
    /// Class to handle logging if the ILogger is passed in Paddle constructor
    /// </summary>
    internal  class LgLogger
    {
        private ILogger _logger;

        public LgLogger(ILogger loger)
        {
            _logger = loger;
        }

        public void LogInformation(string message)
        {
            if(_logger != null)
            {
                _logger.LogInformation(message);
            }
        }

        public void LogError(string message)
        {
            if (_logger != null)
            {
                _logger.LogError(message);
            }
        }
        public void LogWarning(string message)
        {
            if (_logger != null)
            {
                _logger.LogWarning(message);
            }
        }

        public void LogCritical(string message)
        {
            if (_logger != null)
            {
                _logger.LogCritical(message);
            }
        }
    }
}
