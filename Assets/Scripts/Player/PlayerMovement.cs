using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _currentJumpVelocity;
    private Vector3 _moveVelocity;
    public Transform character;
    private bool _isJumping;
    public Perks playerPerks;
    private float _speed = 4;

    void Start()
    {
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        _moveVelocity = Vector3.zero;
        _moveVelocity.x = Input.GetAxis("Horizontal");
        _moveVelocity.z = Input.GetAxis("Vertical");
        if (playerPerks.activeSpeed == true)
        {
            _speed = 6;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (!_isJumping)
            {
                _isJumping = true;
                _currentJumpVelocity = Vector3.up * 4;
            }
        }

        if (_isJumping)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(character.localRotation * (_moveVelocity * (_speed + 1) + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }

            else
            {
                controller.Move(character.localRotation * (_moveVelocity * _speed + _currentJumpVelocity) * Time.deltaTime);
                _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            }

            if (controller.isGrounded)
            {
                _isJumping = false;
            }
        }

        else
        {
            controller.SimpleMove(character.localRotation * (_moveVelocity * (_speed - 1) ));
        }

        if (Input.GetKey(KeyCode.LeftShift) && controller.isGrounded)
        {
            controller.SimpleMove(character.localRotation * (_moveVelocity * _speed));
        }
    }
}