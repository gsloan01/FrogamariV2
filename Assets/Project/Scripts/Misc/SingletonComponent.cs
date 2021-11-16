using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get
        {
            //Check if there isn't a currently existing object
            if (instance == null)
            {
                //See if it exists in the hierarchy
                instance = GameObject.FindObjectOfType<T>();
            }

            //Check if it is still null
            if (instance == null)
            {
                //Create a new object with this script
                instance = new GameObject().AddComponent<T>();
                instance.gameObject.name = instance.GetType().Name;
            }

            //return instance
            return instance;
        } 
    }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
