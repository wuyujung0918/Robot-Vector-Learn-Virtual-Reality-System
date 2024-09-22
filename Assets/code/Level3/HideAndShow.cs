using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAndShow : MonoBehaviour
{
    public Button CKButton, PosButton, ArrowButton;
    public GameObject RedArrow;
    public GameObject[] GreenArrow;
    public GameObject[] YellowPos;
    public Transform point1;  // 第一個點
    public Transform point2;  // 第二個點
    public Text[] ArrowTexts, PosTexts;
    public Image AEImage, PosImage, VecImage;
    public Text AEText;


    // Start is called before the first frame update
    void Start()
    {
        // 隱藏按鈕,UI
        RedArrow.gameObject.SetActive(false);
        AEImage.enabled = false;
        AEText.enabled = false;
        PosImage.enabled = false;
        VecImage.enabled = false;

        // 隱藏GreenArrow中的所有GameObject
        foreach (GameObject greenArrowObject in GreenArrow)
        {
            greenArrowObject.SetActive(false);
        }

        foreach (Text ArrowText in ArrowTexts)
        {
            ArrowText.enabled = false;
        }

        // 隱藏YellowPos中的所有GameObject
        foreach (GameObject yellowPosObject in YellowPos)
        {
            yellowPosObject.SetActive(false);
        }

        foreach (Text PosText in PosTexts)
        {
            PosText.enabled = false;
        }

        // 綁定按鈕點擊事件
        CKButton.onClick.AddListener(OnClickCKButton);
        PosButton.onClick.AddListener(OnClickPosButton);
        ArrowButton.onClick.AddListener(OnClickArrowButton);
    }

    public void OnClickArrowButton()
    {
        // 在PosButton被點擊時顯示YellowPos中的所有GameObject
        foreach (GameObject arrowPosObject in GreenArrow)
        {
            arrowPosObject.SetActive(!arrowPosObject.gameObject.activeSelf);
           
        }
        foreach (Text ArrowText in ArrowTexts)
        {
            ArrowText.enabled = !ArrowText.enabled;
        }
        VecImage.enabled = !VecImage.enabled;
    }

    // 新增方法来切换GreenArrow和ArrowTexts的显示状态
    

    void OnClickPosButton()
    {
        // 在PosButton被點擊時顯示YellowPos中的所有GameObject
        foreach (GameObject yellowPosObject in YellowPos)
        {
            yellowPosObject.SetActive(!yellowPosObject.gameObject.activeSelf);
        }
        foreach (Text PosText in PosTexts)
        {
            PosText.enabled = !PosText.enabled;
        }
        PosImage.enabled = !PosImage.enabled;
    }

    void OnClickCKButton()
    {
        // 切換可見性
        RedArrow.gameObject.SetActive(!RedArrow.gameObject.activeSelf);
        AEImage.enabled = !AEImage.enabled;
        AEText.enabled = !AEText.enabled;
    }
    // Update is called once per frame
    void Update()
    {
        // 檢查是否有兩個點
        /*if (point1 != null && point2 != null)
        {
            // 計算兩點的距離
            float distance = Vector3.Distance(point1.position, point2.position);

            // 根據距離調整RedArrow的尺寸
            RedArrow.transform.localScale = new Vector3(distance * 0.002f, 0.001f, 0.001f);
        }*/
    }
}
