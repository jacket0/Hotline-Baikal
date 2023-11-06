using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float RotationSpeed;
    public float Speed;
    [SerializeField] private float _maxHelth;
    public float Health { get; private set; }
    private static float _minHealth = 0f;

    public float Damage;
    public float AttackRange;
    public float AttackRate;

    public bool IsAlive = true;

    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private ScoreDisplay _scoreDisplay;

    private float nextAttackTime = 0f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _scoreDisplay = _player.gameObject.GetComponent<ScoreDisplay>();
        _playerTransform = _player.transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        Health = _maxHelth;
        IsAlive = true;
    }

    void FixedUpdate()
    {
        if (IsAlive)
        {
            if (Vector2.Distance(transform.position, _playerTransform.position) <= AttackRange)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            _animator.SetTrigger("isAttack");
            _player.TakeDamage(Damage);
            nextAttackTime = Time.time + 1f / AttackRate;
        }
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("isDamaged");
        Health -= damage;
        if (Health <= _minHealth)
        {
            Die();
        }
    }

    void Die()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _animator.SetBool("isDie", true);
        _scoreDisplay.KillTimer();
        _scoreDisplay.Kill();
    }

    public void DestroyYacher()
    {
        Destroy(gameObject);
    }
}