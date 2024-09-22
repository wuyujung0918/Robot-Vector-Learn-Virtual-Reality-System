using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeInterac : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public Text slopeText;

    void Update()
    {
        // 计算两个物体之间的高度差和水平距离
        float roundedX1 = Mathf.Floor(object1.position.x * 100);
        float roundedX2 = Mathf.Floor(object2.position.x * 100);
        float roundedY1 = Mathf.Floor(object1.position.y * 100);
        float roundedY2 = Mathf.Floor(object2.position.y * 100);
        
        float verticalDistanceY = (roundedY2 - roundedY1) / 10;
        float horizontalDistanceX = (roundedX2 - roundedX1) / 10;

        // 如果水平距离为0，避免除以0错误
        if (horizontalDistanceX == 0)
        {
            slopeText.text = "无穷大";
        }
        else
        {
            
            // 计算斜率
            float slope = verticalDistanceY / horizontalDistanceX;
            // 将斜率显示在UI Text组件上
            slopeText.text = slope.ToString("F1");
        }
    }
}
