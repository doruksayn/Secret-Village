using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BulletSpawner : MonoBehaviour
{
    public int bulletCount;
    public Transform bullet;
    private Transform _preBullet;

    void Start()
    {
        StartCoroutine(bulletTimer());
    }

    void Update()
    {
    }

    IEnumerator bulletTimer()
    {
        while (true)
        {
            if (bulletCount <= 3)
            {
                _preBullet = Instantiate(bullet, RandomLocation(), transform.rotation);
                bulletCount++;
                yield return new WaitForSeconds(4);
            }

            yield return null;
        }
    }

    private Vector3 RandomLocation()
    {
        var randomLocation = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5),
            transform.position.y, Random.Range(transform.position.z - 5, transform.position.z + 5));
        return randomLocation;
    }
}