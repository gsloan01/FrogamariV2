using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private CinemachineBrain cineBrain;
    private CinemachineVirtualCamera cineCamera;


    private void Awake()
    {
        cineBrain = gameObject.InstantiateComponent<CinemachineBrain>();
        cineCamera = gameObject.InstantiateComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
