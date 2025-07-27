using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyCountUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public float money;

    void Start()
    {
    }


    void Update()
    {
        moneyText.text = money + "$";
    }
}