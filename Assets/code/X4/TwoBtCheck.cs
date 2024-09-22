using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoBtCheck : MonoBehaviour
{
    public Button AButtons, BButtons, CButtons, CheckButtons, nextbutton; // 你的所有按钮数组
    public Button A1Bt, B1Bt, C1Bt;
    public Image CorrectImage, WrongImage;

    private void Start()
    {

        AButtons.onClick.AddListener(OnButtonAClick);
        BButtons.onClick.AddListener(OnButtonBClick);
        CButtons.onClick.AddListener(OnButtonCClick);
        A1Bt.onClick.AddListener(OnButtonA1Click);
        B1Bt.onClick.AddListener(OnButtonB1Click);
        C1Bt.onClick.AddListener(OnButtonC1Click);
        CheckButtons.onClick.AddListener(OnButtonCheckClick);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
    }

    void ResetButtonInteractability()
    {
        AButtons.interactable = true;
        BButtons.interactable = true;
        CButtons.interactable = true;
        A1Bt.interactable = true;
        B1Bt.interactable = true;
        C1Bt.interactable = true;
    }

    void OnButtonAClick()
    {
        if (AButtons.interactable)
        {
            BButtons.interactable = !BButtons.interactable;
            CButtons.interactable = !CButtons.interactable;
        }
    }

    void OnButtonBClick()
    {
        if (BButtons.interactable)
        {
            AButtons.interactable = !AButtons.interactable;
            CButtons.interactable = !CButtons.interactable;
        }
    }

    void OnButtonCClick()
    {
        if (CButtons.interactable)
        {
            AButtons.interactable = !AButtons.interactable;
            BButtons.interactable = !BButtons.interactable;
        }
    }

    void OnButtonA1Click()
    {
        B1Bt.interactable = !B1Bt.interactable;
        C1Bt.interactable = !C1Bt.interactable;
    }

    void OnButtonB1Click()
    {
        A1Bt.interactable = !A1Bt.interactable;
        C1Bt.interactable = !C1Bt.interactable;
    }

    void OnButtonC1Click()
    {
        A1Bt.interactable = !A1Bt.interactable;
        B1Bt.interactable = !B1Bt.interactable;
    }


    void OnButtonCheckClick()
    {

        if (AButtons.interactable || CButtons.interactable || A1Bt.interactable || C1Bt.interactable)
        {
            // 如果任何一个按钮还处于可交互状态，则显示 WrongImage
            CorrectImage.enabled = false;
            WrongImage.enabled = true;
            StartCoroutine(HideWrongImageAfterDelay(2f));
            ResetButtonInteractability();
        }
        else
        {
            // 如果所有按钮都不可交互，则显示 CorrectImage
            CorrectImage.enabled = true;
            WrongImage.enabled = false;
            nextbutton.gameObject.SetActive(true);
        }
    }

    IEnumerator HideWrongImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 在等待指定时间后隐藏WrongImage
        if (WrongImage != null)
        {
            WrongImage.enabled = false;
        }
        else
        {
            Debug.LogError("WrongImage not assigned!");
        }
    } 
}
