using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemy;
    public int enemyCounter;
    protected Transform _preEnemyRange;

    protected virtual void Start()
    {
        StartCoroutine(enemyTimer());
    }

    void Update()
    {
    }

    protected virtual Vector3 RandomLocation()
    {
        var randomLocation = new Vector3(Random.Range(transform.position.x - 15, transform.position.x + 15),
            transform.position.y,
            Random.Range(transform.position.z - 10, transform.position.z + 30));
        return randomLocation;
    }

    IEnumerator enemyTimer()
    {
        while (true)
        {
            if (enemyCounter < 2)
            {
                _preEnemyRange = Instantiate(enemy, RandomLocation(), transform.rotation);
                enemyCounter++;
                yield return new WaitForSeconds(3);
            }

            yield return null;
        }
    }
}