using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    private float minimumY = -60f;
    private float maximumY = 60f;
    private float sensitivity = 5f;

    public Transform character;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseX += sensitivity * Input.GetAxis("Mouse X");
        _mouseY -= sensitivity * Input.GetAxis("Mouse Y");
        _mouseY = Mathf.Clamp(_mouseY, minimumY, maximumY);

        transform.localRotation = Quaternion.Euler(_mouseY, _mouseX, 0);

        character.localRotation = Quaternion.Euler(0, _mouseX, 0);
    }
}