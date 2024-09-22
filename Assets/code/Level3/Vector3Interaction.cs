using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vector3Interaction : MonoBehaviour
{
    public Camera camera;
    public Transform targetObject1;
    public Transform targetObject2;
    public Text textMesh;


    private bool isRed = false;
    private bool isUpdatingCoordinates = true;
    private static Text currentRedText = null; // 追蹤當前是紅色的Text
    void Start()
    {

    }


    void Update()
    {
        if (isUpdatingCoordinates)
        {
            if (targetObject1 != null && targetObject2 != null)
            {
                // Calculate floating-point vector positions
                Vector3 position1 = new Vector3(targetObject1.position.x, targetObject1.position.y, targetObject1.position.z);
                Vector3 position2 = new Vector3(targetObject2.position.x, targetObject2.position.y, targetObject1.position.z);

                // Now you can use position1 and position2 as needed
                // For example, you can update the textMesh with the calculated positions

                // Calculate the vector between the two objects
                //Vector3 vectorBetweenObjects = position2 - position1;

                // Round each component of the vector to two decimal places
                float roundedX1 = Mathf.Floor(position1.x * 100);
                float roundedY1 = Mathf.Floor(position1.y * 100);
                float roundedZ1 = Mathf.Floor(position1.z * 100);
                float roundedX2 = Mathf.Floor(position2.x * 100);
                float roundedY2 = Mathf.Floor(position2.y * 100);
                float roundedZ2 = Mathf.Floor(position2.z * 100);

                // Perform subtraction after rounding
                float roundedVectorX = (roundedX2 - roundedX1) / 10;
                float roundedVectorY = (roundedY2 - roundedY1) / 10;
                float roundedVectorZ = (roundedZ2 - roundedZ1) / 10;

                // 格式化坐标字符串，包括小数点后一位
                string vectorText = $": ({roundedVectorX:F1}, {roundedVectorZ:F1}, {roundedVectorY:F1})";

                // 更新TextMesh文本
                textMesh.text = vectorText;


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

