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
        InputManager.Instance.onSwipe += ControlPlanetRotation;
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

    void ControlPlanetRotation(Swipe swipe)
    {        
        //Debug.Log(swipe.SwipeDirection.x + ", " + swipe.SwipeDirection.y);
        ////Normalized Vector2 (-1 to 1)
        Vector2 swipeDir = swipe.SwipeDirection;

        transform.RotateAroundLocal(new Vector3(-swipeDir.y * rotationSpeed, swipeDir.x * rotationSpeed, 0), 20);
        //target = new Vector3(-swipeDir.y * rotationSpeed, swipeDir.x * rotationSpeed, 0);
    }
}
