using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseThreeObj : MonoBehaviour
{
    public GameObject Orig1, Orig2, Orig3;
    public Button OrigBt1, OrigBt2, OrigBt3;

    // Start is called before the first frame update
    void Start()
    {
        Orig1.gameObject.SetActive(false);
        Orig2.gameObject.SetActive(false);
        Orig3.gameObject.SetActive(false);
       
        OrigBt1.onClick.AddListener(ShowOrig1);
        OrigBt2.onClick.AddListener(ShowOrig2);
        OrigBt3.onClick.AddListener(ShowOrig3);
    }

    void ShowOrig1()
    {
        // 显示 Orig1
        Orig1.SetActive(true);
        // 隐藏 Orig2
        Orig2.SetActive(false);
        // 隐藏 Orig3
        Orig3.SetActive(false);
    }

    void ShowOrig2()
    {
        // 显示 Orig1
        Orig2.SetActive(true);
        // 隐藏 Orig2
        Orig1.SetActive(false);
        // 隐藏 Orig3
        Orig3.SetActive(false);
    }

    void ShowOrig3()
    {
        // 显示 Orig1
        Orig3.SetActive(true);
        // 隐藏 Orig2
        Orig2.SetActive(false);
        // 隐藏 Orig3
        Orig1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
