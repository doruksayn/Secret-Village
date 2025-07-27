using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMoneyFollow : MonoBehaviour
{
    private Transform _prePlayer;
    private float _rotationSpeed = 3f;
    private Quaternion startRotation;
    private Vector3 startPosition;

    void Start()
    {
        _prePlayer = GameObject.FindWithTag("Player").transform;
        startRotation = transform.rotation;
        startPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _prePlayer.position) <= 15)
        {
            Vector3 targetDirection = new Vector3(_prePlayer.position.x, transform.position.y, _prePlayer.position.z) -
                                      new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 newRotation =
                Vector3.RotateTowards(transform.forward, -targetDirection, _rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
        }
        else if (Vector3.Distance(transform.position, _prePlayer.position) >= 15)
        {
            Vector3 targetDirection = startRotation * Vector3.forward;
            Vector3 newRotation =
                Vector3.RotateTowards(transform.forward, targetDirection, _rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
        }
    }
}