using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyPistolBullet : MonoBehaviour
{
    private Vector3 _currentLocation;

    void Start()
    {
        _currentLocation = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(_currentLocation, gameObject.transform.position) > 1000000)
        {
            Destroy(gameObject);
        }

        //Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
        }
    }
}