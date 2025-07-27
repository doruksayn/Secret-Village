using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Perks : MonoBehaviour
{
    public Perks refPerks;
    public GameObject armorUI;
    void Start()
    {
        refPerks.activeArmor = true;
        refPerks.activeSpeed = true;
        refPerks.activeDMG = true;
        armorUI.SetActive(true);
        
    }


    void Update()
    {
    }
}