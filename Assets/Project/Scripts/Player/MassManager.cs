using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MassManager : SingletonComponent<MassManager>
{
    [SerializeField]
    private float baseMass;
    
    public float CurrentMass { get; set; }

    public delegate void MassDelegate(float mass);
    public static event MassDelegate massUpdate;
    public static event MassDelegate massRatioUpdate;
    

    [SerializeField]
    private float baseScale;
    [SerializeField]
    private float scaleMod;

    void Awake()
    {
        CurrentMass = baseMass;
        base.Awake();
    }

    public void ChangeMass(float mass)
    {
        CurrentMass += mass;
        Debug.Log(CurrentMass);
        float newMass = (CurrentMass - baseMass) * scaleMod + baseScale;

        transform.DOScale(new Vector3(newMass, newMass, newMass), 0.5f);
        massUpdate?.Invoke(CurrentMass);
        massRatioUpdate?.Invoke(newMass);

        Mouth.Instance.line.startWidth += mass * scaleMod;
        Mouth.Instance.line.endWidth += mass * scaleMod;
    }
}
