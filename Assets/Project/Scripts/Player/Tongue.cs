using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public float speed = 1;
    public float mouthRange = 0.5f;
    public bool lerpMovement = false;
    public bool canMove = true;

    bool hitTarget = false;

    void Update()
    {
        Vector3 targetPosition = Vector3.zero;

        //Move towards the target
        if (!hitTarget) targetPosition = Mouth.Instance.target.transform.position;
        //Move back to the mouth
        else targetPosition = Mouth.Instance.transform.position;

        if (canMove)
        {
            Vector3 movement;
            if (lerpMovement) movement = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            else movement = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            transform.position = movement;
        }

        //Check range to mouth
        bool withinRange = Vector3.Distance(transform.position, Mouth.Instance.transform.position) <= mouthRange;
        if (hitTarget && withinRange)
        {
            //Destroy when back at the mouth
            Mouth.Instance.TurnOffLineRenderer();
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
