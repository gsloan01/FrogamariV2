using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PopUpSelectable : MonoBehaviour
{
    void Awake()
    {
        InputManager.Instance.onTouchStart += SelectButton;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position);
        //Ray ray = Camera.main.ScreenToWorldPoint(Mouse.current.position);
        //if (Physics.Raycast(ray, out RaycastHit hit, 100))
        //{
        //    Debug.Log(hit.transform.name);
        //    Debug.Log("hit");
        //}
    }

    void SelectButton(UnityEngine.InputSystem.LowLevel.TouchState touch)
    {
        //touch.position
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }
}
