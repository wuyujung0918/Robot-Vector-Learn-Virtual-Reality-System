using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransfromRob : MonoBehaviour
{
    public Button BtnXPlus, BtnXReduce, BtnYPlus, BtnYReduce, BtnZPlus, BtnZReduce;
    public GameObject TargetObject;
    public float moveStep = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        BtnXPlus.onClick.AddListener(() => TaskOnClickPlus(Vector3.right));
        BtnXReduce.onClick.AddListener(() => TaskOnClickReduce(Vector3.left));
        BtnYPlus.onClick.AddListener(() => TaskOnClickPlus(Vector3.forward));
        BtnYReduce.onClick.AddListener(() => TaskOnClickReduce(Vector3.back));
        BtnZPlus.onClick.AddListener(() => TaskOnClickPlus(Vector3.up));
        BtnZReduce.onClick.AddListener(() => TaskOnClickReduce(Vector3.down));
    }

    void TaskOnClickPlus(Vector3 axis)
    {
        MoveObject(axis * moveStep);
    }

    void TaskOnClickReduce(Vector3 axis)
    {
        MoveObject(axis * moveStep);
    }

    void MoveObject(Vector3 offset)
    {
        if (TargetObject != null)
        {
            // 移动物体的位置
            Vector3 newPosition = TargetObject.transform.position + offset;

            // 确保每个轴的坐标不低于0
            newPosition.x = Mathf.Max(newPosition.x, 0);
            newPosition.y = Mathf.Max(newPosition.y, 0);
            newPosition.z = Mathf.Max(newPosition.z, 0);

            TargetObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("目标物体未设置！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
