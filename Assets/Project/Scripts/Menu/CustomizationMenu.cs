using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    [SerializeField] PlayerData data;
    [SerializeField] public List<CosmeticsManager> cosmeticManagers;

    public Image leftHat, rightHat, leftColor, rightColor;
    int index = -1;

    private void OnEnable()
    {
        Debug.Log("Starting with no hat moment");
    }

    public void SwapHat(string direction)
    {
        if(data.unlocked.Count > 0 || data.unlocked == null)
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
                Debug.Log("You cant spell idiot");
            }
            Debug.Log("index : " + index.ToString());
            data.hat = (index > data.unlocked.Count || index <= -1) ? null : data.unlocked[index];
            
            
        }
        else Debug.Log("No hats owned");
        foreach (var v in cosmeticManagers) v.UpdateHat();
    }
    public void SwapColor(string direction)
    {
        if (data.unlockedColorSchemes.Count > 1)
        {
            if (direction.ToLower().Equals("left"))
            {
                index--;
                if (index == -1)
                {
                    index = data.unlockedColorSchemes.Count - 1;

                }
            }
            else if (direction.ToLower().Equals("right"))
            {
                index++;
                if (index == data.unlockedColorSchemes.Count)
                {
                    index = 0;
                }
            }
            else
            {
                Debug.Log("You cant fucking spell idiot");
            }
            data.currentScheme =  data.unlockedColorSchemes[index];
            Debug.Log($"current color is {data.unlockedColorSchemes[index].name}");
            

        }
        
        foreach (var v in cosmeticManagers) v.UpdateColor();
    }


}
