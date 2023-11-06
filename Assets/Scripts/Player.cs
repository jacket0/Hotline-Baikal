using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private static float _minHealth = 0f;
    public float Health;
    public int Damage;
    public int Speed;
    [SerializeField] private Animator _animator;
    public Animator _headanimator;

    public bool IsAlive
    {
        get
        {
            return (Health > _minHealth);
        }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        Health = _maxHealth;
    }


    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= _minHealth)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("isDie", true);
        _headanimator.SetTrigger("isHurted");
    }
}
