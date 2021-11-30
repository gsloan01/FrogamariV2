using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : SingletonComponent<PlayerCamera>
{
    [SerializeField]
    private Transform target;
    private Camera unityCamera;
    private CinemachineBrain cineBrain;
    private CinemachineVirtualCamera cineCamera;


    private void Awake()
    {
        base.Awake();
        cineBrain = gameObject.InstantiateComponent<CinemachineBrain>();
        cineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
        unityCamera = gameObject.GetComponentInChildren<Camera>();
    }




    public Camera GetCurrentCamera()
    {
        return unityCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
