using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvasSingleton : SingletonComponent<LoadCanvasSingleton>
{
    [SerializeField] SpiralTransition transition;

    private void Awake()
    {
        FindObjectOfType<SceneController>().postloadSceneEvent.AddListener(PostLoad);
    }
    void PostLoad()
    {
        FindObjectOfType<SceneController>().preloadSceneEvent.AddListener(transition.Open);
        FindObjectOfType<SceneController>().postloadSceneEvent.AddListener(transition.Close);
    }
}
