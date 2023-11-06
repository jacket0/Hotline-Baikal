using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private static float _minHealth = 0f;
    private float _health;
    [SerializeField] private int damage;

    private Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= _minHealth)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("isDie", true);
    }
}
