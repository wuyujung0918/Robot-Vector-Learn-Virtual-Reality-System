using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideVideo : MonoBehaviour
{
    public Button hideButton,showButton; // 參照到你的按鈕
    public GameObject videoObject; // 參照到播放影片的GameObject

    void Start()
    {
        // 為按鈕添加監聽器，當按鈕被按下時調用HideVideoObject方法
        hideButton.onClick.AddListener(HideVideoObject);
        showButton.onClick.AddListener(ShowVideoObject);
    }

    void HideVideoObject()
    {
        // 簡單地設置GameObject的active狀態為false來隱藏影片
        videoObject.SetActive(false);
    }

    void ShowVideoObject()
    {
        videoObject.SetActive(true);
    }
}
