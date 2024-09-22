using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{

    public Button BtnUp, BtnDown, BtnRight, BtnLeft, CheckBt, nextbutton;
    public float moveStep = 2.0f;
    public GameObject OriginObject;
    public GameObject TargetObject;
    public Image WrongImage;
    public Image CorrectImage;
    public Vector3 originObjectPosition;

    // Start is called before the first frame update
    void Start()
    {
        BtnRight.onClick.AddListener(() => TaskOnClickPlus(Vector3.right));
        BtnLeft.onClick.AddListener(() => TaskOnClickReduce(Vector3.left));
        BtnUp.onClick.AddListener(() => TaskOnClickPlus(Vector3.up));
        BtnDown.onClick.AddListener(() => TaskOnClickReduce(Vector3.down));
        CheckBt.onClick.AddListener(CheckPosition);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
        // 使用公開變數設置 OriginObject 的初始位置
        OriginObject.transform.position = originObjectPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (OriginObject != null)
        {
            // 移动物体的位置
            Vector3 newPosition = OriginObject.transform.position + offset;

            // 确保每个轴的坐标不低于0
            newPosition.x = Mathf.Max(newPosition.x, 0);
            newPosition.y = Mathf.Max(newPosition.y, 0);


            OriginObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("目标物体未设置！");
        }
    }

    void CheckPosition()
    {
        if (OriginObject != null && TargetObject != null)
        {
            // 判断OriginObject的坐标是否等于TargetObject的坐标
            if (OriginObject.transform.position == TargetObject.transform.position)
            {
                CorrectImage.enabled = true;
                nextbutton.gameObject.SetActive(true);

            }
            else
            {
                WrongImage.enabled = true;

                OriginObject.transform.position = originObjectPosition;
                // 通过协程等待一定时间后隐藏WrongImage
                StartCoroutine(HideWrongImageAfterDelay(2f));
            }
        }
        else
        {
            Debug.LogError("目标物体未设置！");
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
