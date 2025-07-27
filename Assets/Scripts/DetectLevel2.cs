using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectLevel2 : MonoBehaviour
{
    public SMGMechanic refSmg;
    public Perks refPerks;
    public GameObject roadToLevel2;
    public TextMeshProUGUI level2Warn;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (refSmg._activeCheck == true && refPerks.activeDMG == true)
        {
            roadToLevel2.SetActive(true);
            level2Warn.text = "New path opened. It is end of the road.";
        }
    }
}


