
using UnityEngine;

/// <summary>
/// Edit -> Project Setting -> Player -> Other Settings -> Scripting Define Symbol setting
/// 'DEBUGGER' 해당 심볼을 위 경로에 정의하면 됌.
/// </summary>
public static class Debugger
{
    public static void Log(string message)
    {
        #if DEBUGGER
        Debug.Log(message);
        #endif
    }

    public static void LogWarning(string message)
    {
        #if DEBUGGER
        Debug.LogWarning(message);
        #endif
    }

    public static void LogError(string message)
    {
        #if DEBUGGER
        Debug.LogError(message);
        #endif
    }
}