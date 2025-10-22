using JetBrains.Annotations;

namespace Anycraft.Features.Frame.Logger
{
    [UsedImplicitly]
    public static class LogUtils
    {
        public const string LogMessageFormat = "[{0}] [{1}.{2}] {3}";

        public static string FormatLog(LogType logType, string className, string memberName, string message)
        {
            var logTypeString = logType.ToString();

            return string.Format(LogMessageFormat, logTypeString, className, memberName, message);
        }
    }
}