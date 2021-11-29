using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static T InstantiateComponent<T>(this GameObject gameObject) where T : Component
    {
        T newComponent = gameObject.GetComponent<T>();

        if (newComponent == null) newComponent = gameObject.AddComponent<T>();

        return newComponent;
    }

    public static T InstantiateComponent<T>(this Component component) where T : Component
    {
        return component.gameObject.InstantiateComponent<T>();
    }

    public static T InstantiateComponent<T>(this GameObject gameObject, out bool wasCreated) where T : Component
    {
        wasCreated = false;
        T newComponent = gameObject.GetComponent<T>();

        if (newComponent == null)
        {
            newComponent = gameObject.AddComponent<T>();
            wasCreated = true;
        }

        return newComponent;
    }

    public static T InstantiateComponent<T>(this Component component, out bool wasCreated) where T : Component
    {
        return component.gameObject.InstantiateComponent<T>(out wasCreated);
    }
}
