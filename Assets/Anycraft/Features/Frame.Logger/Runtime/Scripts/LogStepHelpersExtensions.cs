using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Logger
{
    [UsedImplicitly]
    public static class LogStepHelpersExtensions
    {
        private enum StepState
        {
            Started,
            Skipped,
            Interrupted,
            Completed,
        }

        public const string LogMessageFormat = "step: '{0}', state: '{1}'";

        private static string FormatMessage(string step, StepState stepState)
        {
            return string.Format(LogMessageFormat, step, stepState.ToString());
        }

        public static void LogStepStarted(
            Object context,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            context.LogDebug(FormatMessage(step, StepState.Started), file, member);
        }

        public static void LogStepStarted<T>(
            this T contetx,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            contetx.LogDebug(FormatMessage(step, StepState.Started), file, member);
        }

        public static void LogStepCompleted(
            Object context,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            context.LogDebug(FormatMessage(step, StepState.Completed), file, member);
        }

        public static void LogStepCompleted<T>(
            this T contetx,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            contetx.LogDebug(FormatMessage(step, StepState.Completed), file, member);
        }

        public static void LogStepSkipped(
            Object context,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            context.LogWarning(FormatMessage(step, StepState.Skipped), file, member);
        }

        public static void LogStepSkipped<T>(
            this T contetx,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            contetx.LogWarning(FormatMessage(step, StepState.Skipped), file, member);
        }

        public static void LogStepInterrupted(
            Object context,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            context.LogError(FormatMessage(step, StepState.Interrupted), file, member);
        }

        public static void LogStepInterrupted<T>(
            this T contetx,
            string step,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = ""
        )
        {
            contetx.LogError(FormatMessage(step, StepState.Interrupted), file, member);
        }
    }
}