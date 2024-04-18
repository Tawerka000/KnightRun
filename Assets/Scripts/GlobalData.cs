using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static bool isPaused { get; private set; }
    private static void Start()
    {
        isPaused = false;
    }
    public static void Pause()
    {
        isPaused = true;
    }
    public static void Unpause()
    {
        isPaused = false;
    }
}
