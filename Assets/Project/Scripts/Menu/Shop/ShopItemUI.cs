using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public CustomizationItemData data;
    public Image icon;
    public TMP_Text costBox;
    public PlayerData player;
    public UnityEvent<ShopItemUI> OnPurchase;



    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
    }
    public void Set(CustomizationItemData itemData)
    {
        data = itemData;
        icon.sprite = itemData.icon;
        costBox.text = itemData.cost.ToString();
        gameObject.SetActive(true);
        transform.DOScale(1, 1);
    }

    public void PurchaseItem()
    {
        if(player.coins >= data.cost)
        {
            player.coins -= data.cost;

            CoinDisplay.Instance.UpdateCoins();
            OnPurchase.Invoke(this);
            transform.DOScale(0, .25f);
            Destroy(gameObject, .25f);
        }

    }
}
