using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointLine : MonoBehaviour
{
    public Transform[] startPoints; // 起点
    public Transform[] endPoints; // 终点
    public bool isAtoE, isTrangle, isVector;
    private LineRenderer lineRenderer;


    void Start()
    {
        // 获取或添加 LineRenderer 组件
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
      

        // 设置线的宽度
        lineRenderer.startWidth = 0.06f;
        lineRenderer.endWidth = 0.06f;

        // 创建新材质并设置颜色
        Material newMaterial = new Material(Shader.Find("Sprites/Default"));

        if (isAtoE)
        {
            newMaterial.color = Color.Lerp(Color.red, Color.white, 0.2f);// 这会创建一个亮红色

        }else if (isTrangle)
        {
            newMaterial.color = Color.black;
        }else if (isVector)
        {
            newMaterial.color = Color.black;
            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
        }
        else
        {
            newMaterial.color = Color.Lerp(Color.blue, Color.white, 0.7f); 
        }
        
        lineRenderer.material = newMaterial;
    }

    void Update()
    {
        // 确保起点和终点数组长度相同
        if (startPoints.Length != endPoints.Length)
        {
            Debug.LogError("起点和终点数组长度不一致！");
            return;
        }

        // 更新线的位置
        lineRenderer.positionCount = startPoints.Length * 2;
        for (int i = 0; i < startPoints.Length; i++)
        {
            lineRenderer.SetPosition(i * 2, startPoints[i].position);
            lineRenderer.SetPosition(i * 2 + 1, endPoints[i].position);
        }
    }
}
