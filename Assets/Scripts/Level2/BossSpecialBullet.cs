using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialBullet : MonoBehaviour
{
    private float bulletSpeed = 40;
    public Rigidbody bullet;
    private Rigidbody _bulletPre;
    public Boss _refBoss;
    private bool teleported;

    void Start()
    {
        StartCoroutine(BulletTimer());
    }

    void Update()
    {
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
            if (_refBoss._enemyHealth <= 400)
            {
                BulletFire();
                yield return new WaitForSeconds(1);
                
            }
            else if (_refBoss._enemyHealth <= 400)
            {
                BulletFire();
                yield return new WaitForSeconds(1);
                
            }

            yield return null;
        }
    }
}
