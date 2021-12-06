using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class LickUIManager : SingletonComponent<LickUIManager>
{
    public List<LickUI> lickUIs = new List<LickUI>();
    [SerializeField] Canvas LickUICanvas;
    [SerializeField] Interactable test;
    [SerializeField] LickUI prefab;
    bool toggleTest = true;

    /// <summary>
    /// This method will be called by the consumable to display a lick ui when it is in range and the player is the correct size.
    /// </summary>
    /// <param name="thisObject">Object to display UI for</param>
    public void DisplayLickUI(Interactable thisObject)
    {
        //Get every lickUI where that consumable is used.
        IEnumerable<LickUI> foundLickUIs = lickUIs.Where(x => x.consumable == thisObject);

        //if the lickUI's doesn't have one for this object
        if (foundLickUIs.Count() == 0)
        {
            //Make one

            LickUI newUI = Instantiate(prefab, LickUICanvas.gameObject.transform);
            newUI.consumable = thisObject;
            newUI.Open();
            lickUIs.Add(newUI);
        }
        else if(foundLickUIs.Count() == 1) // if there is one with that object
        {
            foundLickUIs.First().Open();
        }
        else // there are duplicates
        {
            Debug.Log($"Duplicate LickUI's for {thisObject.name}");
        }
    }

    /// <summary>
    /// This method will be called by the consumable to close a lick ui when the range is too far or the player isn't the correct size.
    /// </summary>
    /// <param name="thisObject">Object to remove UI for</param>
    public void CloseLickUI(Interactable thisObject)
    {
        //Find the gameObjects ui and close it
        lickUIs.Where(x => x.consumable == thisObject).First().Close();
    }

    public void DisableManager()
    {
        for (int i = 0; i < lickUIs.Count; i++)
        {
            Destroy(lickUIs[i].gameObject);
        }
        lickUIs.Clear();
        enabled = false;
    }


    public void Clear()
    {
        lickUIs.ForEach(x => Destroy(x));
        lickUIs.Clear();
    }

    public bool TryGetLickUI(Interactable interactable, out LickUI found)
    {
        bool exists = false;
        found = null;
        return exists;
    }

    public void OnClick()
    {
        if(toggleTest)
        {
            DisplayLickUI(test);
        }
        else
        {
            CloseLickUI(test);
        }
    }
}

