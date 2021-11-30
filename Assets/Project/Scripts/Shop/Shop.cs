using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopItemUI itemUI;
    [SerializeField] GameObject shopList;
    [SerializeField] float delayBetween;

    private AudioSource audioSource;

    public List<CustomizationItemData> items = new List<CustomizationItemData>();
    List<ShopItemUI> created = new List<ShopItemUI>();

    bool opening = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartCoroutine(OpenShop());
    }
    private void OnDisable()
    {
        opening = false;

        foreach(var v in created)
        {
            Destroy(v.gameObject);
        }
        created.Clear();
    }

    IEnumerator OpenShop()
    {
        opening = true;
        foreach(var v in items)
        {
            if (!opening) break;
            if(!created.Any(n => n.data == v))
            {
                ShopItemUI newUI = Instantiate(itemUI, shopList.transform);

                newUI.Set(v);
                created.Add(newUI);

                newUI.OnPurchase.AddListener(RemoveShopItem);
                yield return new WaitForSeconds(delayBetween);
            }
        }
        opening = false;
    }
    
    public void RemoveShopItem(ShopItemUI ui)
    {
        audioSource?.Play();
        created.Remove(ui);
    }

}
