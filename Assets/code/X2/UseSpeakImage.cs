using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSpeakImage : MonoBehaviour
{
    public Image UseImage, SpeakImage; // 将图像对象拖拽到Inspector窗口以关联
    public Button UseBt, SpeakBt, CloseUseBt, CloseSpeakBt;

    void Start()
    {
        // 初始化时将图像设置为不可见
        UseImage.gameObject.SetActive(false);
        SpeakImage.gameObject.SetActive(false);


        // 添加按钮点击事件
        UseBt.onClick.AddListener(ShowUseImage);
        SpeakBt.onClick.AddListener(ShowSpeakImage);
        CloseUseBt.onClick.AddListener(UseImageVisibility);
        CloseSpeakBt.onClick.AddListener(ToggleSpeakImageVisibility);
    }

    void ShowUseImage()
    {
        // 点击按钮时将图像设置为可见
        UseImage.gameObject.SetActive(true);
    }

    void ShowSpeakImage()
    {
        SpeakImage.gameObject.SetActive(true);
    }


    void ToggleSpeakImageVisibility()
    {
        
            SpeakImage.gameObject.SetActive(!SpeakImage.gameObject.activeSelf);
                                   
                
    }

    void UseImageVisibility()
    {
        UseImage.gameObject.SetActive(!UseImage.gameObject.activeSelf);
    }
}
