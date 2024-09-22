using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject fromObject;
    public GameObject toObject;

    private GameObject arrow;

    void Start()
    {
        GenerateArrow();
    }

    void GenerateArrow()
    {
        Vector3 direction = toObject.transform.position - fromObject.transform.position;
        Vector3 arrowPosition = (fromObject.transform.position + toObject.transform.position) / 2f;

        arrow = Instantiate(arrowPrefab, arrowPosition, Quaternion.identity);
        arrow.transform.up = direction;
    }
}
