using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportBoss : MonoBehaviour
{
    public Boss _refBoss;
    private bool teleported = false;


    void Start()
    {
        StartCoroutine(teleport());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator teleport()
    {
        while (true)
        {
            if (_refBoss._enemyHealth <= 400 && teleported == false)
            {
                transform.position = new Vector3(-53, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(4);
                teleported = true;
            }
            else if (_refBoss._enemyHealth <= 400 && teleported == true)
            {
                transform.position = new Vector3(-17, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(4);
                teleported = false;
            }


            yield return null;
        }
    }
}