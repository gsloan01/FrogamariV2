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
        #region Timer testing

        //timer += Time.deltaTime;

        //if (timer >= 5)
        //{
        //    if (target != null)
        //    {
        //        CreateTongue();
        //        timer = 0;
        //    }
        //}
        #endregion
    }

    public void CreateTongue()
    {
        tongueObject = Instantiate(tongue.gameObject, transform);
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
