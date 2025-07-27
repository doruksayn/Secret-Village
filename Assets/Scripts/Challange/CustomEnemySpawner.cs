using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEnemySpawner : EnemySpawner
{
    protected override void Start()
    {
        StartCoroutine(enemyTimer());
    }


    void Update()
    {
    }

    protected override Vector3 RandomLocation()
    {
        var randomLocation = new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10),
            transform.position.y,
            Random.Range(transform.position.z - 5, transform.position.z + 5));
        return randomLocation;
    }

    IEnumerator enemyTimer()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            if (enemyCounter < 5)
            {
                _preEnemyRange = Instantiate(enemy, RandomLocation(), transform.rotation);
                enemyCounter++;
                yield return new WaitForSeconds(2);
            }

            yield return null;
        }
    }
}