using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputManager : SingletonComponent<InputManager>
{
    private PlayerControls playerControls;

    public delegate void TouchDelegate(TouchState touch);
    public delegate void SwipeDelegate(Swipe swipe);

    /// <summary>Event for the beginning of a touch</summary>
    public event TouchDelegate onTouchStart;
    /// <summary>Event during a touch</summary>
    public event TouchDelegate onTouchUpdate;
    /// <summary>Event after a touch</summary>
    public event TouchDelegate onTouchEnd;

    /// <summary>Event after a swipe</summary>
    public event SwipeDelegate onSwipe;
    private double swipeStartTime;
    private Swipe currentSwipe;
    

    public override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
        playerControls.Enable();

        //Instantiate all controls
        playerControls.TouchScreen.PrimaryTouch.performed += TouchUpdate;


        onTouchEnd += OnSwipe;
    }



    #region Touch Events
    private void TouchUpdate(InputAction.CallbackContext obj)
    {
        TouchState value = obj.ReadValue<TouchState>();

        if (value.phase == UnityEngine.InputSystem.TouchPhase.Began) TouchStart(obj);

        onTouchUpdate?.Invoke(value);

        if (value.phase == UnityEngine.InputSystem.TouchPhase.Ended) TouchEnd(obj);
    }

    private void TouchStart(InputAction.CallbackContext obj)
    {
        //Debug.Log("Start Touch");
        swipeStartTime = Time.timeAsDouble;

        TouchState value = obj.ReadValue<TouchState>();
        currentSwipe.startPosition = value.position;
        onTouchStart?.Invoke(value);
    }

    private void TouchEnd(InputAction.CallbackContext obj)
    {
        //Debug.Log("End Touch");
        TouchState value = obj.ReadValue<TouchState>();
        onTouchEnd?.Invoke(value);
    }
    #endregion

    #region Swipe Events
    private void OnSwipe(TouchState touch)
    {
        double swipeTime = Time.timeAsDouble - swipeStartTime;
        currentSwipe.endPosition = touch.position;

        if (swipeTime > 0.1d && currentSwipe.SwipeDistance > 50)
        {
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
    public Touch lastTouch;
    public double swipeTime;
    public Vector2 SwipeDirection
    {
        get
        {
            return (endPosition - startPosition).normalized;
        }
    }

    public float SwipeDistance
    {
        get
        {
            return (endPosition - startPosition).magnitude;
        }
    }

    public override string ToString()
    {
        return $"Swipe: {startPosition} to {endPosition} over {swipeTime} seconds.";
    }
}
