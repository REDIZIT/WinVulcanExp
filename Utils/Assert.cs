using System;
using System.Diagnostics;
using Silk.NET.Vulkan;

public static partial class Assert
{
    [StackTraceHidden]
    public static void That(bool predicate, string message)
    {
        if (predicate == false)
        {
            throw new Exception(message);
        }
    }
}

public static partial class Assert
{
    [StackTraceHidden]
    public static void Success(Result result, string operationName)
    {
        if (result != Result.Success)
        {
            throw new Exception($"'{operationName}' failed with result: {result}");
        }
    }
}