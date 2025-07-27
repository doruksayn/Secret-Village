using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireMechanic : MonoBehaviour
{
    private float bulletSpeed = 40;
    public Rigidbody bullet;
    private Rigidbody _bulletPre;
    private Transform playerLocation;

    void Start()
    {
        playerLocation = GameObject.FindWithTag("Player").transform;
        StartCoroutine(BulletTimer());
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerLocation.position) <= 50)
        {
            Vector3 newDirection =
                new Vector3(playerLocation.position.x, playerLocation.position.y + 1, playerLocation.position.z);
            transform.LookAt(newDirection);
        }
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
            yield return new WaitForSeconds(1);
            if (Vector3.Distance(transform.position, playerLocation.position) <= 50)
            {
                BulletFire();
                yield return new WaitForSeconds(2);
            }

            yield return null;
        }
    }
}
