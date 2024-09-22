using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    public FakeArmCtrl FakeArm;
    // Start is called before the first frame update
    void Start()
    {
        FakeArm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z)) {
            FakeArm.EventClick(1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FakeArm.EventClick(2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FakeArm.EventClick(11);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FakeArm.EventClick(12);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FakeArm.EventClick(21);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            FakeArm.EventClick(22);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FakeArm.EventClick(31);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FakeArm.EventClick(32);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FakeArm.EventClick(41);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            FakeArm.EventClick(42);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            FakeArm.EventClick(51);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FakeArm.EventClick(52);
        }*/
    }
}
