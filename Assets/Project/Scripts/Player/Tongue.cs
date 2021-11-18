using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public float speed = 1;
    public bool lerpMovement = false;

    bool hitTarget = false;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetPosition = Vector3.zero;

        //Move towards the target
        if (!hitTarget) targetPosition = Mouth.Instance.target.transform.position;
        //Move back to the mouth
        else targetPosition = Mouth.Instance.transform.position;

        Vector3 movement;
        if (lerpMovement) movement = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        else movement = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        transform.position = movement;

        //Destroy when back at the mouth
        if (hitTarget && transform.position == Mouth.Instance.transform.position)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            if (interactable == Mouth.Instance.target)
            {
                Mouth.Instance.target.Interact();
                hitTarget = true;
            }
        }
    }
}
