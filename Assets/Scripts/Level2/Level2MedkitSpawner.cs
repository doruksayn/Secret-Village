using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2MedkitSpawner : MonoBehaviour
{
    public int medkitCount;
    public Transform medkit;
    private Transform _preMedkit;

    void Start()
    {
        StartCoroutine(medkitTimer());
    }


    void Update()
    {
    }

    IEnumerator medkitTimer()
    {
        while (true)
        {
            if (medkitCount <= 3)
            {
                _preMedkit = Instantiate(medkit, RandomLocation(), transform.rotation);
                medkitCount++;
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