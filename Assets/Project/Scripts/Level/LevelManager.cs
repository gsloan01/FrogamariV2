using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : SingletonComponent<LevelManager>
{
    [SerializeField] private float levelTime;
    [SerializeField] private List<MassEvent> events;

    public PlayerData playerData;

    private void Start()
    {
        MassManager.massUpdate += OnMassUpdate;
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
    }
}

[Serializable]
public class MassEvent
{
    public bool triggered;
    public float playerMass;
    public UnityEvent invokedEvents;
}
