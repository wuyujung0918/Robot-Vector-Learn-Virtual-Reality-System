using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetControl : MonoBehaviour
{
    public GameObject TargetObject,Ch4que;
    public Button CKButton;
    public Button ConfirmButton;
    public float positionTolerance = 0.01f; // 您可以根據需要調整這個值
    public Image CorrectImage, WrongImage;
    public Button nextbutton, againbutton;

    // Start is called before the first frame update
    void Start()
    {
        TargetObject.SetActive(false);
        Ch4que.SetActive(false);
        ConfirmButton.gameObject.SetActive(false);
        CKButton.onClick.AddListener(OnCKButtonClick);
        ConfirmButton.onClick.AddListener(OnConfirmButtonClick);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCKButtonClick()
    {
        TargetObject.SetActive(true);
        Ch4que.SetActive(true);
        CKButton.gameObject.SetActive(false); // 隱藏測驗按鈕
        ConfirmButton.gameObject.SetActive(true); // 顯示確認按鈕
    }
    void OnConfirmButtonClick()
    {
        if (CheckAnswer())
        {
            Debug.Log("答案正確!");
            CorrectImage.enabled = true;
            WrongImage.enabled = false;
            nextbutton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("答案不正確!");
            CorrectImage.enabled = false;
            WrongImage.enabled = true;
            againbutton.gameObject.SetActive(true);
        }
    }

    bool CheckAnswer()
    {
        // 使用 CheckTrigger.cs 中的檢查邏輯
        Collider[] colliders = Physics.OverlapSphere(transform.position, positionTolerance);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("TargetTag")) // 假設您已經有一個帶有 "TargetTag" 標籤的物體
            {
                return true; // 如果找到標籤，則答案正確
            }
        }
        return false; // 如果沒有找到標籤，則答案不正確
    }
}
