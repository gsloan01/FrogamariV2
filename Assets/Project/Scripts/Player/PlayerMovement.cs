using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : SingletonComponent<PlayerMovement>
{
    private Animator animator;
    private NavMeshAgent meshAgent;
    [SerializeField]
    private float jumpDistance = 2;

    private void Awake()
    {
        base.Awake();

        animator = GetComponentInChildren<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        InputManager.Instance.onSwipe += OnSwipe;
    }

    private void OnDisable()
    {
        InputManager.Instance.onSwipe -= OnSwipe;
    }


    private void OnSwipe(Swipe swipe)
    {
        Vector3 position = transform.position;
        Vector2 swipeDir = swipe.SwipeDirection;

        position += new Vector3(swipeDir.x, 0, swipeDir.y) * jumpDistance;

        meshAgent.SetDestination(position);

        //Change Later to Look Better (Anim Events)
        animator.SetTrigger("Jump");
    }
}
