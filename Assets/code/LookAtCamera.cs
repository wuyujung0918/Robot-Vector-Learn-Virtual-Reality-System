using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    private void Update()
    {
        // 使物體朝向自身的前方
        transform.forward = Vector3.forward;
    }
}
