using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        InputManager.Instance.onTouchStart += IncreaseScale;
        InputManager.Instance.onTouchEnd += DecreaseScale;
        InputManager.Instance.onSwipe += Shift;
    }

    private void OnDisable()
    {
        InputManager.Instance.onTouchStart -= IncreaseScale;
        InputManager.Instance.onTouchEnd -= DecreaseScale;
        InputManager.Instance.onSwipe -= Shift;
    }

    private void IncreaseScale(TouchState touch)
    {
        //Debug.Log(touch.position);

        transform.localScale *= 1.5f;
    }

    private void DecreaseScale(TouchState touch)
    {
        //Debug.Log(touch.position);

        transform.localScale = new Vector3(1,1,1);
    }

    private void Shift(Swipe swipe)
    {
        Vector2 swipeOffset = swipe.SwipeDirection;
        transform.position += new Vector3(swipeOffset.x, swipeOffset.y, 0);
    }
}
