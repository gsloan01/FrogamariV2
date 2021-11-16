using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonComponent<InputManager>
{
    private PlayerControls playerControls;

    public delegate void TouchDelegate(Vector2 position);
    public delegate void SwipeDelegate(Swipe swipe);

    public event TouchDelegate onTouchStart;
    public event TouchDelegate onTouchUpdate;
    public event TouchDelegate onTouchEnd;

    public event SwipeDelegate onSwipe;
    private double swipeStartTime;
    private Swipe currentSwipe;
    

    public override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();

        //Instantiate all controls
        playerControls.TouchScreen.PressPosition.started += TouchStart;
        playerControls.TouchScreen.PressPosition.performed += TouchUpdate;
        playerControls.TouchScreen.PressPosition.canceled += TouchEnd;

        onTouchEnd += OnSwipe;
    }



    #region Touch Events
    private void TouchStart(InputAction.CallbackContext obj)
    {
        Debug.Log("Start Touch");
        swipeStartTime = Time.timeAsDouble;

        Vector2 value = obj.ReadValue<Vector2>();
        currentSwipe.startPosition = value;
        onTouchStart?.Invoke(value);
    }

    private void TouchUpdate(InputAction.CallbackContext obj)
    {
        Vector2 value = obj.ReadValue<Vector2>();
        onTouchUpdate?.Invoke(value);
    }

    private void TouchEnd(InputAction.CallbackContext obj)
    {
        Debug.Log("End Touch");
        Vector2 value = obj.ReadValue<Vector2>();
        onTouchEnd?.Invoke(value);
    }
    #endregion

    #region Swipe Events
    private void OnSwipe(Vector2 position)
    {
        double swipeTime = Time.timeAsDouble - swipeStartTime;

        if (swipeTime > 0.1d)
        {
            currentSwipe.endPosition = position;
            currentSwipe.swipeTime = swipeTime;

            Debug.Log(currentSwipe);
            onSwipe?.Invoke(currentSwipe);
        }
    }
    #endregion


}

public struct Swipe
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public double swipeTime;
    public Vector2 SwipeDirection
    {
        get
        {
            return (endPosition - startPosition).normalized;
        }
    }

    public override string ToString()
    {
        return $"Swipe: {startPosition} to {endPosition} over {swipeTime} seconds.";
    }
}
