using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerkWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public FlowerCountUI refFlowerCount;

    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (refFlowerCount.flower >= 15)
        {
            warningText.text = "Speed boost activated.";
        }
    }
}