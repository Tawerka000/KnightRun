using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : MonoBehaviour
{
    [SerializeField] private float time = 20f;
    private float timer = 0f;
    [SerializeField] private int capacity = 0;
    [SerializeField] private int maxCapacity = 2;
    [SerializeField] private Image[] shieldsImages;
    private float fill;
    private AudioSource audioSource;
    [SerializeField] private AudioClip getShield;
    private void Start()
    {
        foreach (Image image in shieldsImages)
        {
            image.fillAmount = 0;
        }
        audioSource = GetComponent<AudioSource>();
        maxCapacity = shieldsImages.Length;
    }
    private void Update()
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        if (timer < time && capacity < maxCapacity)
        {
            timer += Time.deltaTime;
            shieldsImages[capacity].fillAmount += (1/time) * Time.deltaTime;
        }
        else
        {
            timer = 0f;
            if (capacity < maxCapacity)
            {
                audioSource.PlayOneShot(getShield);
                capacity++;
            }
        }
    }
    public bool UseShield()
    {
        if(capacity > 0)
        {
            if (capacity == maxCapacity)
            {
                capacity--;
                float a = shieldsImages[capacity].fillAmount;
                for (int i = capacity; i < maxCapacity; i++)
                {
                    shieldsImages[i].fillAmount = 0;
                }
                shieldsImages[capacity - 1].fillAmount = a;
                
            }
            else
            {
                float a = shieldsImages[capacity].fillAmount;
                for (int i = capacity; i < maxCapacity; i++)
                {
                    shieldsImages[i].fillAmount = 0;
                }
                capacity--;
                shieldsImages[capacity].fillAmount = a;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}