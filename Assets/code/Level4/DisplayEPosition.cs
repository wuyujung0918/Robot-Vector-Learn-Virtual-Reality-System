using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEPosition : MonoBehaviour
{
    public Transform targetObject;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 更新TextMesh显示目标物体的坐标
        if (targetObject != null)
        {
            // 获取目标物体的坐标
            Vector3 targetPosition = targetObject.position;

            // 将浮点坐标值四舍五入为整数
            int x = Mathf.RoundToInt(targetPosition.x);
            int y = Mathf.RoundToInt(targetPosition.y);
            int z = Mathf.RoundToInt(targetPosition.z);

            // 格式化坐标字符串
            string coordinatesText = $"({x}, {z}, {y})";

            // 更新TextMesh文本
            textMesh.text = coordinatesText;
        }
    }
}
