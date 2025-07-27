using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MedkitSpawner : MonoBehaviour
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
        var randomLocation = new Vector3(Random.Range(transform.position.x - 15, transform.position.x + 15),
            transform.position.y, Random.Range(-30, 25));
        return randomLocation;
    }
}