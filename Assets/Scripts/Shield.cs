using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : MonoBehaviour
{
    public float time;
    public static int capacity;
    public int max_capacity;
    public Image shields;
    public float fill;
    void Start()
    {
        fill = 0f;
        capacity = 0;
        StartCoroutine(CapacityIncrease());
    }
    void Update()
    {
        shields.fillAmount = fill + 0.05f * capacity;
    }
    void Repeat()
    {
        StartCoroutine(CapacityIncrease());
    }
    IEnumerator CapacityIncrease()
    {
        yield return new WaitForSeconds(time);
        if (capacity < max_capacity)
        {
            capacity++;
        }
        Repeat();
    }

}