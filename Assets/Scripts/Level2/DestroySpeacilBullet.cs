using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpeacilBullet : MonoBehaviour
{
    private Vector3 _currentLocation;

    void Start()
    {
        _currentLocation = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(_currentLocation, gameObject.transform.position) > 150)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 6);
    }
}