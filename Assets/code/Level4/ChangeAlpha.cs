using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{
    public float alphaValue = 0.7f; // 设置透明度值，范围为0到1

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        Color color = rend.material.color;
        color.a = alphaValue;
        rend.material.color = color;
    }
}
