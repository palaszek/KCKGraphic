using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [InspectorLabel("Settings:")]
    private int coinCount { get; set; }
    [SerializeField] private int coinsToGet;
    [SerializeField] private int coinsToEndLevel;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject endLevel;

    private void Start()
    {
        if(endLevel != null) endLevel.SetActive(false);
    }
    void Update()
    {
        coinText.text = "Monety: " + coinCount.ToString() + "/" + coinsToGet.ToString();
        if(endLevel != null && coinCount >= coinsToEndLevel)
        {
            endLevel.SetActive(true);
        }
    }

    public void AddCoin()
    {
        coinCount++;
    }

    public int GetCoinsCount()
    {
        return coinCount;
    }
}
