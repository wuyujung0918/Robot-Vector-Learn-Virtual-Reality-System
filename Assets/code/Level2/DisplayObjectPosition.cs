using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObjectPosition : MonoBehaviour
{
    public Transform[] targetObjects; // 要显示位置的物体数组
    public Text[] positionTexts; // 对应的UI Text元素数组
    public Text[] Vector3Texts;
    public Button[] positionClicks;// 对应的UI Button元素数组
    public Button[] Vector3Clicks;
    public Button CKButton, OrangeArrow;
    public Text OrangeArrowText;
    public Transform J1; // 第一個物體
    public Transform J6; // 第二個物體

    private bool isTextVisible = true; // 添加一个标志来追踪文字的可见性状态
    private bool isVectorTextVisible = true; // 添加一个标志来追踪向量文字的可见性状态

    private void Start()
    {
        // 隱藏所有文字
        HideAllTexts();

        // 綁定按鈕點擊事件
        for (int i = 0; i < positionClicks.Length; i++)
        {
            int index = i; // 避免閉包的問題
            positionClicks[i].onClick.AddListener(() => ShowObjectPositions(index));
        }

        // 綁定按鈕點擊事件
        for (int i = 0; i < Vector3Clicks.Length; i++)
        {
            int index = i; // 避免閉包的問題
            Vector3Clicks[i].onClick.AddListener(() => CalculateAndDisplayVector(index));
        }

        // 隱藏按鈕,UI
        OrangeArrow.gameObject.SetActive(false);
        OrangeArrowText.gameObject.SetActive(false);

        // 綁定按鈕點擊事件
        CKButton.onClick.AddListener(OnClickCKButton);
        OrangeArrow.onClick.AddListener(OnClickOrangeArrow);
    }

    void OnClickCKButton()
    {
        // 切換可見性
        OrangeArrow.gameObject.SetActive(!OrangeArrow.gameObject.activeSelf);
    }

    void OnClickOrangeArrow()
    {
       OrangeArrowText.gameObject.SetActive(!OrangeArrowText.gameObject.activeSelf); // 切换可见性

        if (OrangeArrowText.gameObject.activeSelf)
        {
            Vector3 vectorBetweenObjects = J6.position - J1.position;
            // 將浮點數坐標轉換為整數
            int roundedX = Mathf.RoundToInt(vectorBetweenObjects.x);
            int roundedY = Mathf.RoundToInt(vectorBetweenObjects.y);
            int roundedZ = Mathf.RoundToInt(vectorBetweenObjects.z);

            OrangeArrowText.text = "Vector: (" + roundedX + ", " + roundedY + ", " + roundedZ + ")";
        }
    }

    public void ShowObjectPositions(int index)
    {
        if (index >= 0 && index < targetObjects.Length &&
            targetObjects[index] != null && positionTexts[index] != null)
        {
            // 獲取物體的位置信息
            Vector3 objectPosition = targetObjects[index].position;

            // 將位置信息的每個分量轉換為整數
            int roundedX = Mathf.RoundToInt(objectPosition.x);
            int roundedY = Mathf.RoundToInt(objectPosition.y);
            int roundedZ = Mathf.RoundToInt(objectPosition.z);


            if (isTextVisible)
            {
                // 將位置信息顯示在 UI Text 上
                positionTexts[index].text = "J" + index + " Pos: (" + roundedX + ", " + roundedY + ", " + roundedZ + ")";
            }
            else
            {
                // 隱藏 UI Text
                positionTexts[index].text = "";
            }

            // 切換文字的可見性標誌
            isTextVisible = !isTextVisible;
        }
        }


    void CalculateAndDisplayVector(int index)
    {
        // 檢查索引是否有效
        if (index >= 0 && index + 1 < targetObjects.Length &&
            targetObjects[index] != null && targetObjects[index + 1] != null)
        {
            // 將兩物體之間的座標轉換為整數向量
            Vector3Int position1 = new Vector3Int(
                Mathf.RoundToInt(targetObjects[index].position.x),
                Mathf.RoundToInt(targetObjects[index].position.y),
                Mathf.RoundToInt(targetObjects[index].position.z)
            );

            Vector3Int position2 = new Vector3Int(
                Mathf.RoundToInt(targetObjects[index + 1].position.x),
                Mathf.RoundToInt(targetObjects[index + 1].position.y),
                Mathf.RoundToInt(targetObjects[index + 1].position.z)
            );

            // 獲取兩個整數向量
            Vector3Int vectorBetweenObjects = position2 - position1;

            if (isVectorTextVisible)
            {
                // 顯示向量信息
                Vector3Texts[index].text = "Vector:" + vectorBetweenObjects;
            }
            else
            {
                // 隱藏 UI Text
                Vector3Texts[index].text = "";
            }

            // 切換文字的可見性標誌
            isVectorTextVisible = !isVectorTextVisible;

        }
    }

    void HideAllTexts()
    {
        // 隱藏所有 UI Text 元素
        foreach (var text in positionTexts)
        {
            if (text != null)
            {
                text.text = "";
            }
        }

        foreach (var text in Vector3Texts)
        {
            if (text != null)
            {
                text.text = "";
            }
        }
    }

    private void Update()
    {
        //Debug.Log(J6.position);
        /*for (int i = 0; i < targetObjects.Length - 1; i++)
        {
            CalculateAndDisplayVector(i);
            ShowObjectPositions(i);
        }*/
    }

}
