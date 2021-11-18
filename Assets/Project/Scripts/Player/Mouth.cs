using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : SingletonComponent<Mouth>
{
    public Tongue tongue;

    public Interactable target;
    public GameObject tongueObject { get; set; }

    float timer = 0;

    void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            CreateTongue();
            timer = 0;
        }
    }

    public void CreateTongue()
    {
        tongueObject = Instantiate(tongue.gameObject, transform);
    }
}
