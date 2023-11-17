using System.Diagnostics;
using System.Drawing;
using UnityEngine;

public enum ColorLog
{
    BLUE,
    RED,
    GREEN,
    YELLOW,
    ORANGE,
    WHITE
}
public class ConsoleLog 
{
    [Conditional("ALL_LOG")]
    public static void LogColor(object message, ColorLog color = ColorLog.WHITE)
    {
        string colorStr = GetColorString(color);
#if ALL_LOG
        UnityEngine.Debug.Log($"<color={colorStr}>{message.ToString()}</color>");
#endif
    }

    [Conditional("ALL_LOG")]
    public static void Log(object message)
    {
#if ALL_LOG
        UnityEngine.Debug.Log(message.ToString());
#endif
    }

    [Conditional("ALL_LOG")]
    public static void LogError(object message)
    {
#if ALL_LOG
        UnityEngine.Debug.LogError(message.ToString());
#endif
    }

    [Conditional("ALL_LOG")]
    public static void LogWarning(object message)
    {
#if ALL_LOG
        UnityEngine.Debug.LogWarning(message.ToString());
#endif
    }



    private static string GetColorString(ColorLog color)
    {
        switch (color)
        {
            case ColorLog.BLUE:
                return "blue";
            case ColorLog.RED:
                return "red";
            case ColorLog.GREEN:
                return "green";
            case ColorLog.YELLOW:
                return "yellow";
            case ColorLog.ORANGE:
                return "yellow";
            case ColorLog.WHITE:
                return "white";
            default:
                return "white";
        }
    }
}
