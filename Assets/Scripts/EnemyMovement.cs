using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Player _player;

    public bool IsMoving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_player != null && _animator)
        {
            _animator.SetBool("isMoving", IsMoving);
            if (_enemy.IsAlive)
            {
                Move();
            }
        }
    }

    private void Move()
    {

        Vector2 direction = _playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        Vector3 target = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.MoveTowards(transform.position, target, _enemy.Speed * Time.deltaTime);
        _rigidbody.MovePosition(currentPosition);
        IsMoving = true;
    }
}
