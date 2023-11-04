using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveVector;
    private Vector3 _cursorDifference;
    [SerializeField] private float Speed = 30f;

    public float RotationAngle { get; private set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        RotateToCursor();
    }

    private void RotateToCursor()
    {
        _cursorDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RotationAngle = Mathf.Atan2(_cursorDifference.y, _cursorDifference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotationAngle - 90);
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.y = Input.GetAxis("Vertical");
        _rb.MovePosition(_rb.position + _moveVector * Speed * Time.deltaTime);
    }


}
