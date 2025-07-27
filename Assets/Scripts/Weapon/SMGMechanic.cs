using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SMGMechanic : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody bullet;
    private Rigidbody _bulletPre;
    public int bulletCount = 50;
    public bool _activeCheck = false;

    void Start()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(BulletTimer());
    }


    void BulletFire()
    {
        var transform1 = transform;
        var eulerAngles = transform1.eulerAngles;
        _bulletPre = Instantiate(bullet, transform1.position, Quaternion.Euler
            (new Vector3((eulerAngles.x + 90), eulerAngles.y, eulerAngles.z)));

        _bulletPre.velocity = transform.forward * bulletSpeed;
    }

    IEnumerator BulletTimer()
    {
        while (true)
        {
            if (Input.GetButtonDown("Fire1") && bulletCount > 0)
            {
                BulletFire();
                bulletCount--;
                yield return new WaitForSeconds((float)0.10);
               
            }

            if (bulletCount == 0)
            {
                yield return new WaitForSeconds(2);
            }

            yield return null;
        }
    }
}