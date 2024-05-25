using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] public float Speed_Scrol = 0.1f;
    [SerializeField] private float y_Scroll;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        y_Scroll = Time.time * Speed_Scrol;
        Vector2 offset = new Vector2(0f, y_Scroll);
        if (spriteRenderer.material.HasProperty("_MainTex"))
        {
            spriteRenderer.material.SetTextureOffset("_MainTex", offset);
        }
    }
}
