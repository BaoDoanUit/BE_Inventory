using System;
using Sentry;
using Sentry.Protocol;

namespace MineralInventory.Helper
{
    public static class SentryClient
    {
        public static void CaptureMessage(String tag, object message, String option)
        {
            SentryLevel level = SentryLevel.Info;
            switch (option)
            {
                case "warning":
                    level = SentryLevel.Warning;
                    break;
                case "error":
                    level = SentryLevel.Error;
                    break;
                default:
                    level = SentryLevel.Info;
                    break;
            }
            using (SentrySdk.Init("http://c1d135f970504633a6e7afe6cedcfc51@115.78.230.192:59070/8"))
            {
                SentrySdk.CaptureMessage(String.Format("{0} :{1}", tag, message), level);
            }
        }

    }
}
