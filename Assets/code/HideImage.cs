using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideImage : MonoBehaviour
{
    public Button[] hideButtons; // 參照到你的多個按鈕
    public GameObject[] imageObjects; // 參照到顯示圖片的多個GameObject

    void Start()
    {
        if (hideButtons.Length != imageObjects.Length)
        {
            Debug.LogError("按鈕和圖片數量不匹配！");
            return;
        }

        for (int i = 0; i < hideButtons.Length; i++)
        {
            int index = i;
            hideButtons[i].onClick.AddListener(() => HideImageObject(index));
        }
    }

    void HideImageObject(int index)
    {
        imageObjects[index].SetActive(!imageObjects[index].activeSelf); // 切換GameObject的激活狀態
    }
}
