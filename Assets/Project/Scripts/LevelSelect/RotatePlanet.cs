using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed, maxAngle = .1f;



    private void Awake()
    {
        InputManager.Instance.onSwipe += ControlPlanetRotation;
        
    }

    void Update()
    {
        
        //lerp deez nuts
    }

    void ControlPlanetRotation(Swipe swipe)
    {
        Quaternion target;
        
        //Debug.Log(swipe.SwipeDirection.x + ", " + swipe.SwipeDirection.y);
        ////Normalized Vector2 (-1 to 1)
        Vector2 swipeDir = swipe.SwipeDirection;

        transform.RotateAroundLocal(new Vector3(-swipeDir.y * rotationSpeed, swipeDir.x * rotationSpeed, 0), 20);

    }
}
