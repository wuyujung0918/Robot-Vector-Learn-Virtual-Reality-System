using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinTogeter : MonoBehaviour
{
    public Camera camera;
    public Transform[] targetObjects; // 要显示位置的物体数组
    public Text[] positionTexts; // 对应的UI Text元素数组
    public Text[] Vector3Texts;
    public Transform[] positionClicks;// 对应的UI Button元素数组
    public Transform[] Vector3Clicks;   
    public Transform J1; // 第一個物體
    public Transform J6; // 第二個物體

    private bool isUpdatingCoordinates = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject == gameObject)
                {
                    isUpdatingCoordinates = !isUpdatingCoordinates;

                    if (isUpdatingCoordinates)
                    {
                        DisplayObjectCoordinates(hitInfo.collider.transform);
                    }
                    else
                    {
                        ClearUIText();
                    }
                }
            }
        }
    }

    void DisplayObjectCoordinates(Transform selectedObject)
    {
        if (targetObjects != null && positionTexts != null)
        {
            for (int i = 0; i < targetObjects.Length; i++)
            {
                if (targetObjects[i] == selectedObject)
                {
                    Vector3 objectPosition = selectedObject.position;
                    int roundedX = Mathf.RoundToInt(objectPosition.x);
                    int roundedY = Mathf.RoundToInt(objectPosition.y);
                    int roundedZ = Mathf.RoundToInt(objectPosition.z);

                    positionTexts[i].text = $"J{i + 1} Pos: ({roundedX}, {roundedY}, {roundedZ})";
                }
            }
        }
    }

    void ClearUIText()
    {
        if (positionTexts != null)
        {
            foreach (Text text in positionTexts)
            {
                text.text = "";
            }
        }
    }
}
