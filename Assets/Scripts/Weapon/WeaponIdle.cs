using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdle : MonoBehaviour
{
    private float _idleSpeed;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(new UnityEngine.Vector3(0, _idleSpeed, 0) * Time.deltaTime);
        if (transform.position.y >= 1.2f)
        {
            _idleSpeed = -0.3f;
        }
        else if (transform.position.y <= 1f)
        {
            _idleSpeed = 0.3f;
        }
    }
}