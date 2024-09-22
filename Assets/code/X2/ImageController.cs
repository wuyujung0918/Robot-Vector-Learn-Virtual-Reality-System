using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public List<Image> imageList;
    public Button nextButton, startButton;

    private int currentIndex = 0;

    void Start()
    {
        // 监听按钮点击事件
        nextButton.onClick.AddListener(OnNextButtonClick);
        startButton.onClick.AddListener(OnNextButtonClick);

        // 初始化显示第一个图像
        ShowImage(currentIndex);
    }

    void OnNextButtonClick()
    {
        // 隐藏当前图像
        HideImage(currentIndex);

        // 切换到下一个图像
        currentIndex++;

        // 如果已经显示了所有图像，隐藏图像和按钮
        if (currentIndex >= imageList.Count)
        {
            HideAll();
        }
        else
        {
            // 显示下一个图像
            ShowImage(currentIndex);
            nextButton.gameObject.SetActive(false);
        }
    }

    void ShowImage(int index)
    {
        if (index >= 0 && index < imageList.Count)
        {
            imageList[index].enabled = true;
        }
    }

    void HideImage(int index)
    {
        if (index >= 0 && index < imageList.Count)
        {
            imageList[index].enabled = false;
        }
    }

    void HideAll()
    {
        // 隐藏所有图像
        foreach (Image image in imageList)
        {
            image.enabled = false;
        }

        // 隐藏按钮
        startButton.gameObject.SetActive(false);
    }
}
