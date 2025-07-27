using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public bool activeArmor = false;
    public GameObject armor;
    public MoneyCountUI refMoneyCount;
    public FlowerCountUI refFlowerCount;
    public PerkWarning refWarning;

    public GameObject armorUI;
    public bool activeDMG = false;
    public bool activeSpeed = false;

    void Start()
    {
        StartCoroutine(warningTimer());
    }

    void Update()
    {
        if (refFlowerCount.flower >= 15)
        {
            activeSpeed = true;
        }
        else
        {
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Armor"))
        {
            if (activeArmor == false && refMoneyCount.money >= 25)
            {
                refMoneyCount.money -= 25;
                activeArmor = true;
                armorUI.SetActive(true);
            }

            if (activeArmor == false && refMoneyCount.money < 25)
            {
            }
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            if (activeDMG == false && refMoneyCount.money >= 100)
            {
                refMoneyCount.money -= 100;
                activeDMG = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            refFlowerCount.flower++;
            Destroy(other.gameObject);
        }
    }

    IEnumerator warningTimer()
    {
        while (true)
        {
            if (refFlowerCount.flower >= 15)
            {
                refWarning.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                refWarning.gameObject.SetActive(false);
                refFlowerCount.flower = 0;
            }
            else
            {
                refWarning.warningText.text = "";
            }

            yield return null;
        }
    }
}