using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Coroutine _attackCoroutine;
    [SerializeField] private BoxCollider2D _hitboxCollider;

    [SerializeField] private float _punchPeriod = 1;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("ActivateHitbox", 0.2f);
            Invoke("DeactivateHitbox", 0.4f);
        }
    }

    void ActivateHitbox()
    {
        _hitboxCollider.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        _hitboxCollider.gameObject.SetActive(false);
    }

    IEnumerable AttackContinuously()
    {
        yield return new WaitForSeconds(_punchPeriod);
    }
}
