using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Camera main;

    [SerializeField] AudioSource SwooshFX;

    [SerializeField]Canvas Title;
    [SerializeField]Canvas MainMenu;
    [SerializeField]Canvas Customize;
    [SerializeField]Canvas Shop;
    [SerializeField]Canvas Options;

    [SerializeField]Color mainMenuBG;
    [SerializeField]Color customizeBG;
    [SerializeField]Color shopBG;

    [SerializeField] float mainMenuAngle = 0;
    [SerializeField] float shopAngle = 120;
    [SerializeField] float customizationAngle = 240;

    [SerializeField] float colorLerpSmoothing = 1.0f;

    Color target;
    float targetAngle;
    

    //private void OnEnable()
    //{
    //    //OnOpenMainMenu();
    //}
    private void Awake()
    {
        target = mainMenuBG;
        targetAngle = 0;
    }

    private void Update()
    {
        if(main.backgroundColor != target)
            main.backgroundColor = Color.Lerp(main.backgroundColor, target, colorLerpSmoothing * Time.deltaTime);


        if (main.gameObject.transform.eulerAngles.y != targetAngle)
            main.gameObject.transform.eulerAngles = new Vector3(0, Mathf.Lerp(main.gameObject.transform.eulerAngles.y, targetAngle, colorLerpSmoothing * Time.deltaTime));
    }

    public void OnOpenCustomization()
    {
        CloseAll();
        Customize.gameObject.SetActive(true);
        target = customizeBG;
        targetAngle = customizationAngle;
        SwooshFX?.Play();
    }

    public void OnOpenMainMenu()
    {
        CloseAll();
        Title.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
        target = mainMenuBG;
        targetAngle = mainMenuAngle;
        SwooshFX?.Play();
    }
    public void OnOpenShop()
    {
        CloseAll();
        Shop.gameObject.SetActive(true);
        target = shopBG;
        targetAngle = shopAngle;
        SwooshFX?.Play();
    }

    public void CloseAll()
    {
        Title.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        Customize.gameObject.SetActive(false);
        Shop.gameObject.SetActive(false);
    }



}
