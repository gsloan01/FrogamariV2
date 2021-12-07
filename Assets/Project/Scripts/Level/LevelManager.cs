using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class LevelManager : SingletonComponent<LevelManager>
{
    private TMP_Text timerText;
    [SerializeField] private float levelTime;
    private float currentTime;
    [SerializeField] private List<MassEvent> events;
    [SerializeField] private Animator loseTextAnimator;
    [SerializeField] SceneController sceneController;

    public PlayerData playerData;

    [SerializeField] private float targetMass;
    private bool gameEnd = false;
    
    private void Start()
    {
        MassManager.massUpdate += OnMassUpdate;
        timerText = GetComponentInChildren<TMP_Text>();
        currentTime = levelTime;
    }

    private void Update()
    {
        if (levelTime > 0) levelTime -= Time.deltaTime;
        int min = (int)(levelTime / 60f);
        int sec = (int)(levelTime % 60f);
        timerText.text = $"{min}:{sec.ToString("D2")}";

        if (levelTime <= 0 && !gameEnd)
        {
            gameEnd = true;
            Lose();
        }
    }

    public void Lose()
    {
        DisablePlayer();
        loseTextAnimator.enabled = true;
        LoadScene("MainMenu_Scene", 7f);
    }
    

    public void Win()
    {
        DisablePlayer();
        playerData.coins += 100;
        PlayerCamera.Instance.OnWin();
    }

    public void LoadScene(string scene, float time)
    {
        StartCoroutine(LoadRoutine(scene, time));
    }

    private IEnumerator LoadRoutine(string scene, float time)
    {
        yield return new WaitForSeconds(time);

        sceneController.OnLoadScene(scene);
    }

    private void DisablePlayer()
    {
        PlayerMovement.Instance.enabled = false;
        Mouth.Instance.enabled = false;
        LickUIManager.Instance.DisableManager();
    }

    private void OnMassUpdate(float mass)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].playerMass < mass && !events[i].triggered)
            {
                events[i].triggered = true;
                events[i].invokedEvents?.Invoke();
            }
        }

        if (mass >= targetMass)
        {
            Debug.Log("Win");
            Win();
        }
    }
}

[Serializable]
public class MassEvent
{
    public bool triggered;
    public float playerMass;
    public UnityEvent invokedEvents;
}
