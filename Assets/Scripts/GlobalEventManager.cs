using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<int> PointGetting = new UnityEvent<int>();
    public static UnityEvent Pause = new UnityEvent();
    public static UnityEvent Unpause = new UnityEvent();
    public static UnityEvent SaveResutl = new UnityEvent();
    public static void PointGet(int num)
    {
        PointGetting.Invoke(num);
    }
    public static void SetPause()
    {
        Time.timeScale = 0f;
        Pause.Invoke();
    }
    public static void SetUnpause()
    {
        Time.timeScale = 1f;
        Unpause.Invoke();
    }
    public static void SetBestScore()
    {
        SaveResutl.Invoke();
    }
}
