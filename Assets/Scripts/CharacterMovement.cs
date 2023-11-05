using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _movementVector
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            return new Vector2(horizontal, vertical);
        }
    }
    private Vector3 _cursorDifference;

    [SerializeField] private float _speed;

    public bool IsMoving
    {
        get
        {
            return (int)_movementVector.magnitude != 0 ? true : false;
        }
    }

    public float RotationAngle { get; private set; }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
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
        _animator.SetBool("isMoving", IsMoving);
        _rigidbody.MovePosition(_rigidbody.position + _movementVector * _speed * Time.deltaTime);
    }
<<<<<<< Updated upstream
=======

     
>>>>>>> Stashed changes
}
