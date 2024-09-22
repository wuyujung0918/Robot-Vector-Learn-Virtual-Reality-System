using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjInterac : MonoBehaviour
{
    public Camera camera;
    public Transform targetObject;
    public Text textMesh;
    
    private bool isRed = false;
    private bool isUpdatingCoordinates = true;
    private static Text currentRedText = null; // 追蹤當前是紅色的Text

    void Start()
    {
        
    }


    void Update()
    {
        // 如果标志为真，持续更新坐标
        if (isUpdatingCoordinates)
        {
            // 如果有目标物体
            if (targetObject != null)
            {
                // 获取目标物体的坐标
                Vector3 targetPosition = targetObject.position;

                float roundedX = Mathf.Floor(targetPosition.x * 100f)/10;
                float roundedY = Mathf.Floor(targetPosition.y * 100f)/10;

                // 格式化坐标字符串，包括小数点后一位
                string coordinatesText = $" : ({roundedX:F1}, {roundedY:F1})";





                // 更新TextMesh文本
                textMesh.text = coordinatesText;
                
                

                
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // 如果點擊到一個物體
                if (hitInfo.collider.gameObject == gameObject)
                {
                    // 如果當前有紅色的Text，將它恢復原色
                    if (currentRedText != null)
                    {
                        currentRedText.color = Color.black; // 假設原本的顏色是黑色
                    }

                    // 設置新的Text為紅色並更新追蹤變量
                    textMesh.color = Color.red;
                    currentRedText = textMesh;
                }
            }
        }
    }
    }
