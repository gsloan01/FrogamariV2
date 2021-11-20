using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : SingletonComponent<MassManager>
{
    [SerializeField]
    private float baseMass;
    
    public float CurrentMass { get; set; }
    

    [SerializeField]
    private float baseScale;
    [SerializeField]
    private float scaleMod;

    void Awake()
    {
        CurrentMass = baseMass;
        base.Awake();
    }

    public void GainMass(float mass)
    {
        CurrentMass += mass;
        Debug.Log(CurrentMass);
        float newMass = (CurrentMass - baseMass) * scaleMod + baseScale;


        transform.localScale = new Vector3(newMass, newMass, newMass);
    }



}
