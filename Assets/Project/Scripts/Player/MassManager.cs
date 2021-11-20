using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : SingletonComponent<MassManager>
{
    public float currentMass;

    void Awake()
    {
        base.Awake();
    }

    public void GainMass(float mass)
    {
        currentMass += mass;
    }

}
