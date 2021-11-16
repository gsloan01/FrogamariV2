using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        InputManager.Instance.onTouchStart += IncreaseScale;
    }

    private void IncreaseScale(Vector2 position)
    {
        Debug.Log(position);

        transform.localScale *= 1.2f;
    }
}
