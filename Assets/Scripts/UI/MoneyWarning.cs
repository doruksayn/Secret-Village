using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public MoneyCountUI refMoneyCount;

    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (refMoneyCount.money < 30)
        {
            warningText.text = "Not Enough Money";
        }
    }
}