using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LickUI : MonoBehaviour
{
    /// <summary>
    /// The consumable this UI represents.
    /// </summary>
    public Interactable consumable;

    /// <summary>
    /// Player camera. Will need to know where the consumable is on the screen.
    /// </summary>
    [SerializeField] Camera playerCamera;

    /// <summary>
    /// Will be used to tell if the UI Element is closing (coroutine/DOTween) or not.
    /// </summary>
    bool closing;
    private void Awake()
    {
        //Debug.Log($"LickUI for {consumable.name} created");
        playerCamera = Camera.main;
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        Mouth.Instance.target = consumable;
        Mouth.Instance.CreateTongue();
    }

    private void Update()
    {
        if(gameObject.activeSelf && !closing)
        {
            transform.position = playerCamera.WorldToScreenPoint(consumable.transform.position);
        }
    }
}
