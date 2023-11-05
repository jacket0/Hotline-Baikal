using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _moveSpeed = 2f;


    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 target = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);

        _rigidbody.MovePosition(currentPosition);
    }
}
