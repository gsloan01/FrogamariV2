using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    //private ShopItemData data;
    private Image icon;
    private TMP_Text textBox;
    public void Set(/*ShopItemData itemData*/)
    {
        icon.sprite = null; //itemData.icon;
        textBox.text = "Item price"; //itemData.price;
        gameObject.SetActive(true);
    }
    public void PurchaseOnClick()
    {
        Debug.Log("Item purchased");
    }
}
