using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeControl : MonoBehaviour
{
    public Button SlopeButton;
    public Text[] SlopeTexts;
    public HideAndShow hideAndShowScript;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text SlopeTexts in SlopeTexts)
        {
            SlopeTexts.enabled = false;
        }

        


        SlopeButton.onClick.AddListener(OnClickSlopeButton);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnClickSlopeButton()
    {
        foreach (Text SlopeTexts in SlopeTexts)
        {
            SlopeTexts.enabled = !SlopeTexts.enabled;
        }
        // 调用HideAndShow脚本来切换GreenArrow和ArrowTexts的显示状态
        //hideAndShowScript.OnClickArrowButton();

    }
}
