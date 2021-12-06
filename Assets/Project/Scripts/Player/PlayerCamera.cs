using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCamera : SingletonComponent<PlayerCamera>
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 baseOffset;
    [SerializeField]
    private Vector3 baseWinOffset;
    private Camera unityCamera;
    private CinemachineBrain cineBrain;
    private CinemachineVirtualCamera cineCamera;
    private CinemachineFramingTransposer cineFraming;
    private bool win = false;

    private float lastMassRatio = 1;

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

    private void KillSelf(Scene arg0, LoadSceneMode arg1)
    {
        ClearPlayerInstances();
    }

    public void OnWin()
    {
        //Add frog transform to lookat
        cineCamera.LookAt = PlayerMovement.Instance.gameObject.transform;
        win = true;
        //Disable movement
        PlayerMovement.Instance.enabled = false;
        PlayerMovement.Instance.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        //Disable eating
        Mouth.Instance.enabled = false;
        LickUIManager.Instance.DisableManager();
        //Change offset
        CurrentOffset = baseWinOffset * lastMassRatio;

        //Start Coroutine
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        //Make frog start spinning
        Animator animator = PlayerMovement.Instance.gameObject.GetComponentInChildren<Animator>();
        animator.SetBool("Win", true);

        //Wait 3 seconds
        yield return new WaitForSeconds(3);

        //Start jump animation
        animator.SetBool("Win", false);
        animator.SetTrigger("Jump");

        //Remove follow
        cineCamera.Follow = null;

        //Wait .2 seconds
        yield return new WaitForSeconds(.3f);

        //Have frog jump very high into the sky, and  have transition play
        PlayerMovement.Instance.gameObject.transform.DOBlendableLocalMoveBy(new Vector3(0, 200, 0), 7);

        LevelManager.Instance.LoadScene("LevelSelect", 3.5f);
        
        
    }

    public void ClearPlayerInstances()
    {
        PlayerMovement.Instance.DestroyInstance();
        LevelManager.Instance.DestroyInstance();
        DestroyInstance();
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
        SceneManager.sceneLoaded += KillSelf;
    }

    public Camera GetCurrentCamera()
    {
        return unityCamera;
    }

    public void ChangeOffset(float massRatio)
    {
        lastMassRatio = massRatio;
        if (!win) CurrentOffset = baseOffset * massRatio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
