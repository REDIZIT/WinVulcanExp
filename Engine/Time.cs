using System;

public static class Time
{
    public static DateTime startTime;
    public static DateTime prevFrameTime;
    public static float deltaTime;
    public static int currentAbsFrame;

    public static void Restart()
    {
        startTime = DateTime.Now;
        prevFrameTime = startTime;
    }

    public static void OnPreRender()
    {
        deltaTime = (float)(DateTime.Now - prevFrameTime).TotalSeconds;
        prevFrameTime = DateTime.Now;

        currentAbsFrame++;
    }
}