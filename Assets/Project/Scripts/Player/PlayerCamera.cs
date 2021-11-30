using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : SingletonComponent<PlayerCamera>
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 baseOffset;
    private Camera unityCamera;
    private CinemachineBrain cineBrain;
    private CinemachineVirtualCamera cineCamera;
    private CinemachineFramingTransposer cineFraming;

    private Vector3 currentOffset;
    public Vector3 CurrentOffset
    {
        get { return currentOffset; }
        set
        {
            currentOffset = value;
            cineFraming.m_TrackedObjectOffset = currentOffset;
        }
    }


    private void Awake()
    {
        base.Awake();
        cineBrain = gameObject.InstantiateComponent<CinemachineBrain>();
        cineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
        cineFraming = cineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        unityCamera = gameObject.GetComponentInChildren<Camera>();
        MassManager.massRatioUpdate += ChangeOffset;
    }

    private void Start()
    {
        if (target == null)
        {
            transform.position = PlayerMovement.Instance.transform.position;
            target = PlayerMovement.Instance.transform;
            cineCamera.Follow = target;
        }

        CurrentOffset = baseOffset;
    }

    public Camera GetCurrentCamera()
    {
        return unityCamera;
    }

    public void ChangeOffset(float massRatio)
    {
        CurrentOffset = baseOffset * massRatio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
