using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed, maxAngle = .1f;

    Vector3 target = Vector3.zero;

    private void Awake()
    {
        InputManager.Instance.onDrag += ControlPlanetRotation;
        target = transform.rotation.eulerAngles;
    }

    void Update()
    {
        //Vector3 currentRotation = transform.rotation.eulerAngles;
        //if (currentRotation != target)
        //{
        //    currentRotation = Vector3.Slerp(currentRotation, target, Time.deltaTime);
        //    transform.RotateAroundLocal(currentRotation, 1);
        //}
    }

    void ControlPlanetRotation(Vector2 vector)
    {        
        //Debug.Log(swipe.SwipeDirection.x + ", " + swipe.SwipeDirection.y);
        ////Normalized Vector2 (-1 to 1)

        transform.RotateAroundLocal(new Vector3(vector.y * rotationSpeed * Time.deltaTime, -vector.x * rotationSpeed * Time.deltaTime, 0), maxAngle);
        //target = new Vector3(-swipeDir.y * rotationSpeed, swipeDir.x * rotationSpeed, 0);
    }
}
