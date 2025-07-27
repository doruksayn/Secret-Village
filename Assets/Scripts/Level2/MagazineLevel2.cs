using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineLevel2 : MonoBehaviour
{
    private float _idleSpeed = 0.5f;
    private Level2BulletSpawner refBullet;

    void Start()
    {
        refBullet = GameObject.Find("BulletSpawner").GetComponent<Level2BulletSpawner>();
    }


    void Update()
    {
        transform.Translate(new UnityEngine.Vector3(0, _idleSpeed, 0) * Time.deltaTime);
        if (transform.position.y >= 1.5f)
        {
            _idleSpeed = -0.5f;
        }
        else if (transform.position.y <= 1f)
        {
            _idleSpeed = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponentInChildren<PistolMechanic>()._activeCheck == true)
            {
                other.gameObject.GetComponentInChildren<PistolMechanic>().bulletCount += 5;
                refBullet.bulletCount--;
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponentInChildren<PistolMechanic>()._activeCheck == false)
            {
                other.gameObject.GetComponentInChildren<SMGMechanic>().bulletCount += 5;
                refBullet.bulletCount--;
                Destroy(gameObject);
            }
        }
    }
}
