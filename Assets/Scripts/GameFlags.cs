using System;
using System.Collections.Generic;

public static class GameFlags
{
    private static readonly Dictionary<string, bool> flags = new Dictionary<string, bool>();

    public static event Action<string, bool> OnFlagChanged;

    public static bool Get(string flagName)
    {
        return flags.TryGetValue(flagName, out bool value) && value;
    }

    public static void Set(string flagName, bool value)
    {
        if (flags.TryGetValue(flagName, out bool current) && current == value) return;
        flags[flagName] = value;
        OnFlagChanged?.Invoke(flagName, value);
    }
}
