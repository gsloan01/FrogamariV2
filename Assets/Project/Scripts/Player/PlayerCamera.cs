using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : SingletonComponent<PlayerCamera>
{
    private Camera camera;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 eulers;


    private void Awake()
    {
        base.Awake();

        GetCamera();
        if (target == null) target = PlayerMovement.Instance.transform;


    }

    private void GetCamera()
    {
        camera = GetComponent<Camera>();

        if (camera == null) camera = gameObject.AddComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Lerp to offset
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        transform.rotation = Quaternion.Euler(eulers);
    }
}
