using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Logger
{
    [UsedImplicitly]
    public static class LogExtensions
    {   
        public static void LogDebug(
            Object context,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.INFO, className, member, message);

            Debug.Log(formattedLog, context);
        }

        public static void LogDebug<T>(
            this T _,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.INFO, className, member, message);

            Debug.Log(formattedLog);
        }

        public static void LogInfo(
            Object context,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.INFO, className, member, message);

            Debug.Log(formattedLog, context);
        }

        public static void LogInfo<T>(
            this T _,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.INFO, className, member, message);

            Debug.Log(formattedLog);
        }

        public static void LogWarning<T>(
            Object context,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.WARN, className, member, message);

            Debug.LogWarning(formattedLog, context);
        }


        public static void LogWarning<T>(
            this T _,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.WARN, className, member, message);

            Debug.LogWarning(formattedLog);
        }

        public static void LogError<T>(
            Object context,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.ERROR, className, member, message);

            Debug.LogError(formattedLog, context);
        }

        public static void LogError<T>(
            this T _,
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            var className = ConvertFileNameToClassName(file);
            var formattedLog = LogUtils.FormatLog(LogType.ERROR, className, member, message);

            Debug.LogError(formattedLog);
        }

        private static string ConvertFileNameToClassName(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            return fileName ?? "Unknown";
        }
    }
}