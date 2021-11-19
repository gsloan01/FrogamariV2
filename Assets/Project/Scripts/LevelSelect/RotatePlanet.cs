using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = .1f;


    private void Awake()
    {
        InputManager.Instance.onSwipe += ControlPlanetRotation;
    }

    void Update()
    {
        
    }

    void ControlPlanetRotation(Swipe swipe)
    {
        Quaternion rotation = transform.rotation;
        Vector2 swipeDir = swipe.SwipeDirection;

        rotation *= Quaternion.Euler(swipeDir.x * rotationSpeed, swipeDir.y * rotationSpeed, 0f);
        //rotation = Quaternion.Euler(swipeDir.x * rotationSpeed, swipeDir.y * rotationSpeed, 0f);

        transform.rotation *= rotation;
    }
}
