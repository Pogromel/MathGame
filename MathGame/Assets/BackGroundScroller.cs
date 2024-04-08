using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] public float Speed_Scrol = 0.1f;
    [SerializeField] private float y_Scroll;
    [SerializeField] private MeshRenderer Material_Renderer;
    
    private void Awake()
    {
        Material_Renderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        y_Scroll = Time.time * Speed_Scrol;
        Vector2 offset = new Vector2(0f , y_Scroll);
        Material_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }

}
