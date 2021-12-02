using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : SingletonComponent<PlayerMovement>
{
    
    public bool canMove { get; set; } = true;
    public float moveMultiplier = 1;
    public float effectTimer = 0;

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
        if (InputManager.InstanceExists) InputManager.Instance.onSwipe -= OnSwipe;
    }


    private void OnSwipe(Swipe swipe)
    {
        if (canMove)
        {
            Vector3 position = transform.position;
            Vector2 swipeDir = swipe.SwipeDirection;

            position += new Vector3(swipeDir.x, 0, swipeDir.y) * jumpDistance * transform.localScale.x * moveMultiplier;

            meshAgent.SetDestination(position);

            //Change Later to Look Better (Anim Events)
            animator.SetTrigger("Jump");
        }
    }

    private void Update()
    {
        if (effectTimer > 0)
        {
            effectTimer -= Time.deltaTime;
        } else
        {
            moveMultiplier = 1;
        }
    }

    public void Confusion(float time)
    {
        moveMultiplier = -1;
        effectTimer = time;
    }
}
