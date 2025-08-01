using System.Drawing;

using MelonLoader;

namespace Submerge.Utilities;

internal static class Logger
{
    private static MelonLogger.Instance _loggerInstance;
    
    internal static void InitializeLogger(MelonLogger.Instance melonLogger)
    {
        _loggerInstance = melonLogger;
    }
    
    internal static void Log(string message)
    {
        _loggerInstance.Msg(Color.Aqua, message);
    }

    internal static void DebugLog(string message)
    {
#if DEBUG
        _loggerInstance.Msg(Color.Aquamarine, message);
#endif
    }

    internal static void Warn(string message)
    {
        _loggerInstance.Msg(Color.Yellow, message);
    }

    internal static void Error(string message)
    {
        _loggerInstance.Msg(Color.Red, message);
    }
}