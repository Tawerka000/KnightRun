using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    public float additionalScrollSpeed;

    public GameObject[] backgrounds;
    public int AmountOfBackgrounds;

    public float[] scrollSpeed;

    private void FixedUpdate ()
    {
        for(int background = 0; background < AmountOfBackgrounds; background++)
        {
            Renderer rend = backgrounds[background].GetComponent<Renderer>();
            float offset = Time.time * (scrollSpeed[background] + additionalScrollSpeed);
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
