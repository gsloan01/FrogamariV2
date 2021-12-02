using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBox : MonoBehaviour
{
    public enum itemType
    {
        Coin,
        Hat
    }

    public List<itemType> types = new List<itemType>();

    public GameObject coinImage;
    public GameObject hatImage;

    public PlayerData playerData;

    public Shop shop;

    public int[] valueTable = 
    { 
        75, //Coins 
        25  //Hat
    };

    public int randomNumber;

    void Awake()
    {
        types.Add(itemType.Coin);
        types.Add(itemType.Hat);
    }

    void Start()
    {
        
    }

    void OnEnable()
    {
        randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            coinImage.SetActive(true);
            playerData.coins += 3;
        }
        else if (randomNumber == 1)
        {
            if (shop.items.Count > 0)
            {
                hatImage.SetActive(true);
                int hatNum = Random.Range(0, shop.items.Count);
                playerData.unlocked.Add(shop.items[hatNum]);
                shop.items.RemoveAt(hatNum);
            }
            else
            {
                coinImage.SetActive(true);
                playerData.coins += 3;
            }
        }
        else
        {
            Debug.Log("Nothing Was Rewarded");
        }
    }

    public void OnDisable()
    {
        coinImage.SetActive(false);
        hatImage.SetActive(false);
    }

    public void ReRollNumber()
    {
        //randomNumber = Random.Range(0, total);
    }

    void Update()
    {
        
    }
}
