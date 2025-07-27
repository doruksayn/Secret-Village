using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCountUI : MonoBehaviour
{
    public TextMeshProUGUI bulletText;
    private int _bulletRef;
    public PistolMechanic _refScript;
    public SMGMechanic _refScriptSMG;

    void Start()
    {
    }
    
    void Update()
    {
        if (_refScript._activeCheck)
        {
            _bulletRef = _refScript.bulletCount;
            bulletText.text = _bulletRef + "";
        }
        else if (_refScript._activeCheck == false)
        {
            _bulletRef = _refScriptSMG.bulletCount;
            bulletText.text = _bulletRef + "";
        }
    }
}