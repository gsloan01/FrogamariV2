using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
    [SerializeField] float rotateRateX = 1;
    [SerializeField] float rotateRateY = 1;
    [SerializeField] float rotateRateZ = 1;
    void Update()
    {
        // Y-Axis
        transform.Rotate(Vector3.up, rotateRateY * Time.deltaTime);
        //Z
        transform.Rotate(Vector3.forward, rotateRateZ * Time.deltaTime);
        //X
        transform.Rotate(Vector3.right, rotateRateX * Time.deltaTime);
    }
}
