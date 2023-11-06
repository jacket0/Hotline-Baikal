using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 3f;
    [SerializeField] private float _maxHelth;
    private float _health;
    [SerializeField] private static float _minHealth = 0f;

    private int _damage = 10;
    private float _attackRange = 1f;
    private float _attackRate = 1f;

    private Animator _animator;
    private Player _player;
    private Transform _playerTransform;

    private float nextAttackTime = 0f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = _playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _playerTransform.position) < _attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                _player.TakeDamage(_damage);
                nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        _animator.SetBool("isDie", true);
    }
}