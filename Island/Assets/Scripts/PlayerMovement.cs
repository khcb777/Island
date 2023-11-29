using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var playerInputNormalized = playerInput.normalized;//Нормализуем вектор чтобы не было быстрого перемещения по диагонали

        _rb.velocity = playerInputNormalized * _speed;
    }
}
