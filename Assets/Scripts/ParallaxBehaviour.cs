using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Renderer[] backgrounds;
    
    [SerializeField] private float[] scrollSpeed;

    private void FixedUpdate ()
    {
        if (GlobalData.isPaused)
        {
            return;
        }
        for (int background = 0; background < backgrounds.Length; background++)
        {
            float offset = Time.time * (scrollSpeed[background]);
            backgrounds[background].material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
