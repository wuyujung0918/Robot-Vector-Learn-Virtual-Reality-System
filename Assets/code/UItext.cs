using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{
    public FakeArmCtrl FakeArm;
    public int btnId;
    public Slider SliderBar;
    public Button BtnLeft, BtnRight;
    public InputField DegreeTxt;
    public float degreeBuf;
    public float MaxBuf;
    public float MinBuf;

    // Start is called before the first frame update
    void Start()
    {
        //degreeBuf = 180;
        BtnLeft.onClick.AddListener(TaskOnClickLeft);
        BtnRight.onClick.AddListener(TaskOnClickRight);
        DegreeTxt.onEndEdit.AddListener(TxtInputEventEnd);
        SliderBar.onValueChanged.AddListener(BarInputEventEnd);

        UpdateDegree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClickLeft()
    {
        Debug.Log("L!");
        if(degreeBuf < MinBuf) 
        {
            degreeBuf = MinBuf;
        }
        else
        {
            degreeBuf -= 1;
        }
        
        UpdateDegree();
    }

    void TaskOnClickRight()
    {
        Debug.Log("R!");
        if (degreeBuf > MaxBuf)
        {
            degreeBuf = MaxBuf;
        }
        else
        {
            degreeBuf += 1;
        }
       
        UpdateDegree();
    }

    void TxtInputEventEnd(string str)
    {
        Debug.Log("str="+str);
        degreeBuf = float.Parse(str);
        UpdateDegree();
    }

    void BarInputEventEnd(float num) {
        degreeBuf = num * 360f;
        UpdateDegree();
    }

    public void UpdateDegree()
    {
        DegreeTxt.text = degreeBuf.ToString("0.00");//�⨤�״��⦨�r���J��r��
        SliderBar.value = degreeBuf/ 360f;//��o/360�o�˴N�|0~1

        //call func (��L���ڬO���@�ի��s�����A���׬O�h��)
        FakeArm.GiveDegree(btnId, degreeBuf);
    }


}
