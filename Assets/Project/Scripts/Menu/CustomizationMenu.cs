using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationMenu : MonoBehaviour
{
    [SerializeField] PlayerData data;
    [SerializeField] public List<CosmeticsManager> cosmeticManagers;

    int index = -1;

    private void OnEnable()
    {
        Debug.Log("Starting with no hat moment");
    }

    public void Swap(string direction)
    {
        if(data.unlocked.Count > 0)
        {
            if(direction.ToLower().Equals("left"))
            {
                index--;
                if (index < -1)
                {
                    index = data.unlocked.Count - 1;

                }
            }
            else if(direction.ToLower().Equals("right"))
            {
                index++;
                if (index == data.unlocked.Count)
                {
                    index = -1;
                }
            }
            else
            {
                Debug.Log("You cant fucking spell idiot");
            }
            data.hat = (index == -1) ? null : data.unlocked[index];
            if (index != -1) Debug.Log($"current hat is {data.unlocked[index].name}");
            else Debug.Log("NO HAT MOMENT");
            
        }
        else Debug.Log("No hats owned");
        foreach (var v in cosmeticManagers) v.UpdateHat();
    }


}
