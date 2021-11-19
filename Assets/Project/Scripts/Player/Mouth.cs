using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : SingletonComponent<Mouth>
{
    public Tongue tongue;

    public Interactable target;
    public GameObject tongueObject { get; set; }

    float timer = 0;
    LineRenderer line;

    void Awake()
    {
        base.Awake();

        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        TurnOffLineRenderer();
    }

    void Update()
    {
        if (tongueObject != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, tongueObject.transform.position);
        }
    }

    void TimerTest()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            if (target != null)
            {
                CreateTongue();
                timer = 0;
            }
        }
    }

    public void CreateTongue()
    {
        if (tongueObject == null)
        {
            tongueObject = Instantiate(tongue.gameObject, transform);
            TurnOnLineRenderer();
        }
    }

    public void TurnOnLineRenderer()
    {
        line.enabled = true;
    }

    public void TurnOffLineRenderer()
    {
        line.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Interactable>(out Interactable interactable))
        {
            LickUIManager.Instance.DisplayLickUI(interactable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Interactable>(out Interactable interactable))
        {
            LickUIManager.Instance.CloseLickUI(interactable);
        }
    }
}
