using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControllerTin : MonoBehaviour
{
    public List<Image> imageList;
    public Button[] nextButton;
    public Button startButton;
    public Button[] returnButtons;

    private int currentIndex = 0;

    void Start()
    {
        // 监听按钮点击事件
        foreach (Button button in nextButton)
        {
            button.onClick.AddListener(OnNextButtonClick);
        }
        startButton.onClick.AddListener(OnNextButtonClick);

        // 监听返回按钮点击事件
        foreach (Button button in returnButtons)
        {
            button.onClick.AddListener(OnReturnButtonClick);
        }
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
            // 隐藏按钮
            
        }

        // 如果当前索引已经是倒数第二张图像，禁用 nextButton
        if (currentIndex == imageList.Count - 1)
        {
            foreach (Button button in nextButton)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void OnReturnButtonClick()
    {
        // 返回上一页
        if (currentIndex > 0)
        {
            // 隐藏当前图像
            HideImage(currentIndex);

            // 切换到上一个图像
            currentIndex--;

            // 显示上一个图像
            ShowImage(currentIndex);

            // 恢复 nextButton 的可见性
            foreach (Button button in nextButton)
            {
                button.gameObject.SetActive(true);
            }
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
        // 隐藏按钮
        foreach (Button button in nextButton)
        {
            button.gameObject.SetActive(false);
        }

        foreach (Button button in returnButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
