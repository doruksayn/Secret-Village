using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PistolMechanic : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody bullet;
    private Rigidbody _bulletPre;
    public int bulletCount = 20;
    public bool _activeCheck = true;

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
        if (_activeCheck)
        {
            _bulletPre = Instantiate(bullet, transform1.position, Quaternion.Euler
                (new Vector3((eulerAngles.x + 90), eulerAngles.y, eulerAngles.z)));

            _bulletPre.velocity = transform.forward * bulletSpeed;
        }
    }

    IEnumerator BulletTimer()
    {
        while (true)
        {
            if (Input.GetButtonDown("Fire1") && bulletCount > 0)
            {
                BulletFire();
                bulletCount--;
                yield return new WaitForSeconds((float)0.50);
                
            }

            if (bulletCount == 0)
            {
                yield return new WaitForSeconds(2);
            }

            yield return null;
        }
    }
}