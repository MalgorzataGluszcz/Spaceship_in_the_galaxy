using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 4.0f;
    Vector2 _playerMovement;
    Rigidbody2D _rb2D;
    Shooting _shooting;

    void Awake()
    {
        _shooting = GetComponent<Shooting>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb2D.velocity = new Vector2(_playerMovement.x * _moveSpeed, _playerMovement.y * _moveSpeed);
    }

    void OnMove(InputValue value)
    {
        _playerMovement = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (_shooting != null)
        {
            _shooting._isFiring = value.isPressed;
        }
    }
}
