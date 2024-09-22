using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObject : MonoBehaviour
{
    public Button ChooseBt1, ChooseBt2, ChooseBt3, nextbutton, CheckButtons, CorrectAns;
    
    
    public Transform targetObject; // 目标物体的Transform组件
    public GameObject Cube1, Cube2,Cube3;
    public float moveSpeed = 5f;
    public Image CorrectImage, WrongImage;
    public GameObject Grab;

    private bool shouldMove = false;
    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;
    private GameObject selectedCube;

    void Start()
    {
        // 初始化数组
        originalPositions = new Vector3[] { Cube1.transform.position, Cube2.transform.position, Cube3.transform.position };
        originalRotations = new Quaternion[] { Cube1.transform.rotation, Cube2.transform.rotation, Cube3.transform.rotation };

        // 为每个按钮添加点击事件侦听器
        ChooseBt1.onClick.AddListener(() => ToggleMoveFlag(Cube1, ChooseBt2, ChooseBt3));
        ChooseBt2.onClick.AddListener(() => ToggleMoveFlag(Cube2, ChooseBt1, ChooseBt3));
        ChooseBt3.onClick.AddListener(() => ToggleMoveFlag(Cube3, ChooseBt1, ChooseBt2));
        CheckButtons.onClick.AddListener(OnButtonCheckClick);
        CheckButtons.gameObject.SetActive(false);
        WrongImage.enabled = false;
        CorrectImage.enabled = false;
        Grab.gameObject.SetActive(true);
    }

    void Update()
    {
        if (shouldMove && selectedCube != null)
        {
            MoveObjectToTarget(selectedCube.transform, targetObject);
            CheckButtons.gameObject.SetActive(true);
        }
        else
        {
            CheckButtons.gameObject.SetActive(false);
        }
    }

    void OnButtonCheckClick()
    {
        
        bool anyOptionSelected = ChooseBt1.interactable || ChooseBt2.interactable || ChooseBt3.interactable;

        if (anyOptionSelected)
        {
            if (CorrectAns != null && CorrectAns.interactable)
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
                ResetButtonInteractability();

                // 将选中的Cube放回原位
                ToggleMoveFlag(selectedCube, ChooseBt1, ChooseBt3);
            }
        }
        else
        {
            // 如果没有选项被选中，则显示 WrongImage
            CorrectImage.enabled = false;
            WrongImage.enabled = true;
            StartCoroutine(HideWrongImageAfterDelay(2f));
        }

        
    }

    void ResetButtonInteractability()
    {
        ChooseBt1.interactable = true;
        ChooseBt2.interactable = true;
        ChooseBt3.interactable = true;
    }

    // 将物体移动到目标位置的方法
    void MoveObjectToTarget(Transform cubeTransform, Transform target)
    {
        // 检查是否有目标物体
        if (cubeTransform != null && target != null)
        {
            // 使用 Lerp 方法平滑移動物體到目标位置
            cubeTransform.position = Vector3.Lerp(cubeTransform.position, target.position, Time.deltaTime * moveSpeed);
            // 使用 Slerp 方法平滑旋轉物體到目标旋轉
            cubeTransform.rotation = Quaternion.Slerp(cubeTransform.rotation, target.rotation, Time.deltaTime * moveSpeed);
            Grab.gameObject.SetActive(false);
            
        }
        else
        {
            Debug.LogError("目标物体未设置！");
            
        }
    }

    // 切换移动标志，并记录选定的Cube
    // 切换移动标志，并处理按钮的交互状态
    void ToggleMoveFlag(GameObject cube, Button otherButton1, Button otherButton2)
    {
        shouldMove = !shouldMove;
        selectedCube = cube;

        // 当选定一个按钮时，禁用其他按钮
        otherButton1.interactable = !shouldMove;
        otherButton2.interactable = !shouldMove;

        // 如果不再移动，将选定的Cube放回原位
        if (!shouldMove && selectedCube != null)
        {
            int cubeIndex = System.Array.IndexOf(new GameObject[] { Cube1, Cube2, Cube3 }, selectedCube);
            selectedCube.transform.position = originalPositions[cubeIndex];
            selectedCube.transform.rotation = originalRotations[cubeIndex];
            Grab.gameObject.SetActive(true);
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
