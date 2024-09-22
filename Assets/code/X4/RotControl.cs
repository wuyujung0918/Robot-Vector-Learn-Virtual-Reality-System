using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotControl : MonoBehaviour
{
    public Button RotBt;
    public Image RotImage;
    public Slider ScaleSlider, RectSlider;
    public float degreeBuf;

    private bool isSliderVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        RotImage.enabled = false;
        ScaleSlider.gameObject.SetActive(false);
        RectSlider.gameObject.SetActive(false);
        RotBt.onClick.AddListener(OnButtonClick);
        ScaleSlider.onValueChanged.AddListener(ScaleObject);
        RectSlider.onValueChanged.AddListener(RotateImage);
    }

    public void OnButtonClick()
    {
        // 切换图像的可见性
        RotImage.enabled = !RotImage.enabled;

        // 切换Slider的可见性
        isSliderVisible = !isSliderVisible;
        ScaleSlider.gameObject.SetActive(isSliderVisible);
        RectSlider.gameObject.SetActive(isSliderVisible);
    }

    void ScaleObject(float scaleFactor)
    {
        degreeBuf = scaleFactor * 360f;
        // 根据Slider的值来缩放图像
        RotImage.rectTransform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
       
    }

    void RotateImage(float rotationAngle)
    {
        degreeBuf = rotationAngle * 360f;
        // 根据Slider的值来旋转图像
        RotImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        
    }

    public void UpdateDegree()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
