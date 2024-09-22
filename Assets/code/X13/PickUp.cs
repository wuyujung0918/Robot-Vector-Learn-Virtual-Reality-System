using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Button ChoosOP,nextbutton, CheckButtons, CorrectAns, PutDownOP, Choose1, Choose2;

    public Transform targetObject; // 目标物体的Transform组件
    public GameObject OPObject, Grab;
    public float moveSpeed = 5f;
    public Image CorrectImage, WrongImage;

    private bool shouldMove = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool correctButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        // 记录初始位置和旋转
        originalPosition = OPObject.transform.position;
        originalRotation = OPObject.transform.rotation;

        // 添加按钮点击事件监听
        ChoosOP.onClick.AddListener(MoveOPObject);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
        CorrectAns.onClick.AddListener(OnCorrectAnsButtonClick);
        Choose1.onClick.AddListener(OnChoose1ButtonClick);
        Choose2.onClick.AddListener(OnChoose2ButtonClick);
        CheckButtons.onClick.AddListener(OnCheckButtonsButtonClick);
        PutDownOP.onClick.AddListener(PutDownOPObject);
        Grab.gameObject.SetActive(true);
    }
    void OnCorrectAnsButtonClick()
    {

        // 当CorrectAns按钮被点击时，将correctButtonPressed设置为true
        correctButtonPressed = true;
        //Choose1.interactable = !Choose1.interactable;
        //Choose2.interactable = !Choose2.interactable;
        // 设置Choose1按钮为半透明，表示已选择
        SetButtonTransparency(CorrectAns, 0.5f);

        // 保持其他按钮可交互且不透明
        SetButtonTransparency(Choose2, 1f);
        SetButtonTransparency(Choose1, 1f);

    }

    void OnChoose1ButtonClick()
    {
        //CorrectAns.interactable = !CorrectAns.interactable;
        //Choose2.interactable = !Choose2.interactable;

        // 设置Choose1按钮为半透明，表示已选择
        SetButtonTransparency(Choose1, 0.5f);

        // 保持其他按钮可交互且不透明
        SetButtonTransparency(Choose2, 1f);
        SetButtonTransparency(CorrectAns, 1f);

    }

    void OnChoose2ButtonClick()
    {
        //CorrectAns.interactable = !CorrectAns.interactable;
        //Choose1.interactable = !Choose1.interactable;

        // 设置Choose2按钮为半透明，表示已选择
        SetButtonTransparency(Choose2, 0.5f);

        // 保持其他按钮可交互且不透明
        SetButtonTransparency(Choose1, 1f);
        SetButtonTransparency(CorrectAns, 1f);

    }

    // 辅助方法用于设置按钮的透明度
    void SetButtonTransparency(Button button, float transparency)
    {
        Color color = button.GetComponent<Image>().color;
        color.a = transparency;
        button.GetComponent<Image>().color = color;
    }

    void OnCheckButtonsButtonClick()
    {

        if (correctButtonPressed)
        {
            CorrectImage.enabled = true;
            WrongImage.enabled = false;
            nextbutton.gameObject.SetActive(true);
        }
        else
        {
            CorrectImage.enabled = false;
            WrongImage.enabled = true;
            StartCoroutine(HideWrongImageAfterDelay(2f));
            Choose1.interactable = true;
            Choose2.interactable = true;
            CorrectAns.interactable = true;


        }

    }
    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            // 计算目标方向和距离
            Vector3 targetPosition = targetObject.position;

            // 使用Vector3.Lerp平滑移动OPObject到目标位置
            OPObject.transform.position = Vector3.Lerp(OPObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 获取目标方向
            //Vector3 directionToTarget = targetPosition - OPObject.transform.position;

            // 计算旋转角度
            Quaternion targetRotation = targetObject.rotation;

            // 使用Quaternion.Slerp平滑旋转OPObject到目标方向
            OPObject.transform.rotation = Quaternion.Slerp(OPObject.transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
            Grab.gameObject.SetActive(false);
        }


    }
    void MoveOPObject()
    {
        shouldMove = true;
    }

    void PutDownOPObject()
    {
        shouldMove = false;
        OPObject.transform.position = originalPosition;
        OPObject.transform.rotation = originalRotation;
        Grab.gameObject.SetActive(true);
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
