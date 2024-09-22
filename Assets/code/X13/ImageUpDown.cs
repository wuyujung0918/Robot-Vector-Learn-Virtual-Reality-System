using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUpDown : MonoBehaviour
{
    public RectTransform imageTransform;
    public Button resetButton;

    private Vector3 originalPosition;
    private bool isMoving = true;
    private float speed = 1.0f;

    private void Start()
    {
        // 保存图片的原始位置
        originalPosition = imageTransform.localPosition;

        // 监听按钮点击事件
        resetButton.onClick.AddListener(ResetPosition);
    }

    private void Update()
    {
        // 如果正在移动，则执行移动逻辑
        if (isMoving)
        {
            MoveImage();
        }
    }

    private void MoveImage()
    {
        // 上下移动图片
        imageTransform.localPosition += Vector3.up * Mathf.Sin(Time.time * speed) * 0.02f;
    }

    private void ResetPosition()
    {
        // 将图片移回原始位置
        imageTransform.localPosition = originalPosition;
    }
}
