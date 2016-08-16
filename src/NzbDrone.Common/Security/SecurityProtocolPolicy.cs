using System;
using System.Net;
using NLog;
using NzbDrone.Common.Instrumentation;

namespace NzbDrone.Common.Security
{
    public static class SecurityProtocolPolicy
    {
        private static readonly Logger Logger = NzbDroneLogger.GetLogger(typeof(SecurityProtocolPolicy));

        public static void Register()
        {
            Logger.Debug("Checking if TLS 1.1 and TLS 1.2 are supported");
            if (Enum.IsDefined(typeof(SecurityProtocolType), 768) && Enum.IsDefined(typeof(SecurityProtocolType), 3072))
            {
                Logger.Info("TLS 1.1 and TLS 1.2 are supported.");
                // TODO: In v3 we should drop support for SSL3 because its very insecure. Only leaving it enabled because some people might rely on it.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            }
        }
    }
}
