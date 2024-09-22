using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckTrigger : MonoBehaviour
{
    public Button CorrectBt;
    
    public float positionTolerance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        CorrectBt.onClick.AddListener(ObTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        // 可以在Update中添加其他逻辑
    }

    void ObTrigger()
    {
        // 这里手动检查触发器
        Collider[] colliders = Physics.OverlapSphere(transform.position, positionTolerance);

        bool triggerHit = false;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("TargetTag"))
            {
                triggerHit = true;
                break;
            }
        }

        if (triggerHit)
        {
            Debug.Log("触发器已触发！");
        }
        else
        {
            Debug.Log("触发器未触发！");
        }
    }
}
