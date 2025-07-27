using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject smg;
    public GameObject pistol;
    public PistolMechanic refPistol;
    public SMGMechanic refSmg;
    public MoneyWarning refWarning;
    public MoneyCountUI refMoneyCount;

    void Start()
    {
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Uzi") && refMoneyCount.money >= 30)
        {
            smg.gameObject.SetActive(true);
            pistol.gameObject.SetActive(false);
            Destroy(other.gameObject);
            refPistol._activeCheck = false;
            refPistol.enabled = false;
            refSmg.enabled = true;
            refSmg._activeCheck = true;
            refMoneyCount.money -= 30;
        }
        else if (other.gameObject.CompareTag("Uzi") && refMoneyCount.money < 30)
        {
            StartCoroutine(warningTimer());
        }
    }

    IEnumerator warningTimer()
    {
        refWarning.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        refWarning.gameObject.SetActive(false);
    }
}