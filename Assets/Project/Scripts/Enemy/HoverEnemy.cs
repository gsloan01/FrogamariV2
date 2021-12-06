using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private float angle = 0;
    [SerializeField] private float maxTurnSpeed;
    private float currentTurnSpeed;
    private float currentTurnTime;
    [SerializeField] private float minTurnTime;
    [SerializeField] private float maxTurnTime;


    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0, 360);
        GetNewTime();
        GetTurnSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDirection();
        ProcessMovement();
    }

    private void GetTurnSpeed()
    {
        float min = Mathf.Min(maxTurnSpeed / 2f, maxTurnSpeed);
        float max = Mathf.Max(maxTurnSpeed / 2f, maxTurnSpeed);
        currentTurnSpeed = Random.Range(min, max);
    }

    private void HandleDirection()
    {
        currentTurnTime -= Time.deltaTime;

        if (currentTurnTime < 0)
        {
            GetNewTime();
            maxTurnSpeed *= -1;
            GetTurnSpeed();
        }

        angle += maxTurnSpeed * Time.deltaTime;
    }

    private void GetNewTime()
    {
        currentTurnTime = Random.Range(minTurnTime, maxTurnTime);
    }

    private void ProcessMovement()
    {
        Vector2 direction = new Vector2();
        direction.x = Mathf.Cos(angle * Mathf.Deg2Rad);
        direction.y = Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector3 newPos = transform.position;

        newPos.x += direction.x * speed * Time.deltaTime;
        newPos.z += direction.y * speed * Time.deltaTime;

        transform.position = newPos;
    }
}
