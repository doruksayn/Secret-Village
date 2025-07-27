using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Medkit : MonoBehaviour
{
    private PlayerHealth _refHealth;
    private float _idleSpeed = 0.5f;
    private MedkitSpawner _refMedkit;


    void Start()
    {
        _refHealth = GameObject.Find("Character").GetComponent<PlayerHealth>();
        _refMedkit = GameObject.Find("MedkitSpawner").GetComponent<MedkitSpawner>();
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
        if (other.gameObject.CompareTag("Player") && _refHealth.playerHealth <= 75)
        {
            _refHealth.playerHealth += 25;
            _refHealth.allHealths[_refHealth.healthCount - 1].gameObject.SetActive(true);
            _refHealth.healthCount -= 1;
            Destroy(gameObject);
            _refMedkit.medkitCount--;
        }
    }
}