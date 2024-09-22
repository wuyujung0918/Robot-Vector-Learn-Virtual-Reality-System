using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformOBJ : MonoBehaviour
{
    public Button BtnXPlus, BtnXReduce, BtnYPlus, BtnYReduce, BtnZPlus, BtnZReduce, CheckBt, PosBt;
    public GameObject OriginObject, TargetObject;
    public Transform PosA, PosB;
    public Image CorrectImage, WrongImage;
    public TextMesh textMeshA, textMeshB;
    public Button nextbutton, againbutton;
    public float maxXLimit = 10.0f;
    public float maxYLimit = 10.0f;
    public float maxZLimit = 10.0f;

    // 移动步长
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
        CheckBt.onClick.AddListener(CheckPosition);
        textMeshA.gameObject.SetActive(false);
        textMeshB.gameObject.SetActive(false);
        PosBt.onClick.AddListener(OnClickPosButton);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 这里可以添加一些额外的逻辑，如果有的话
        // 更新TextMesh显示目标物体的坐标
        if (PosA != null)
        {
            // 获取目标物体的坐标
            Vector3 targetPosition = PosA.position;

            // 将浮点坐标值四舍五入为整数
            int x = Mathf.RoundToInt(targetPosition.x);
            int y = Mathf.RoundToInt(targetPosition.y);
            int z = Mathf.RoundToInt(targetPosition.z);

            // 格式化坐标字符串
            string coordinatesText = $"({x}, {z}, {y})";

            // 更新TextMesh文本
            textMeshA.text = "=" + coordinatesText;
        }

        if (PosB != null)
        {
            // 获取目标物体的坐标
            Vector3 targetPosition = PosB.position;

            // 将浮点坐标值四舍五入为整数
            int x = Mathf.RoundToInt(targetPosition.x);
            int y = Mathf.RoundToInt(targetPosition.y);
            int z = Mathf.RoundToInt(targetPosition.z);

            // 格式化坐标字符串
            string coordinatesText = $"({x}, {z}, {y})";

            // 更新TextMesh文本
            textMeshB.text = "=" + coordinatesText;
        }
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
            Vector3 newPosition = OriginObject.transform.position + offset;

            // 确保每个轴的坐标不低于0
            newPosition.x = Mathf.Clamp(newPosition.x, 0, maxXLimit);
            newPosition.y = Mathf.Clamp(newPosition.y, 0, maxZLimit);
            newPosition.z = Mathf.Clamp(newPosition.z, 0, maxYLimit);

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
                WrongImage.enabled = false;
                nextbutton.gameObject.SetActive(true);
            }
            else
            {
                CorrectImage.enabled = false;
                WrongImage.enabled = true;
                againbutton.gameObject.SetActive(true);
                OriginObject.transform.position = new Vector3(0.14f, 0, 0);
            }
        }
        else
        {
            Debug.LogError("目标物体未设置！");
        }
              
    }
    void OnClickPosButton()
    {
        // 切換可見性
        textMeshA.gameObject.SetActive(!textMeshA.gameObject.activeSelf);
        textMeshB.gameObject.SetActive(!textMeshB.gameObject.activeSelf);
    }

}
