using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDisplay : SingletonComponent<CoinDisplay>
{
    public PlayerData data;
    public TMPro.TMP_Text amount;

    private void OnEnable()
    {
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        amount.text = data.coins.ToString();
    }
}
