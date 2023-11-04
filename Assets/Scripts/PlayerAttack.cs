using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider2D hitbox;

    public Rigidbody2D rb;
    Coroutine attackCoroutine;
    [SerializeField] float punchPeriod = 1;

    void Start()
    {
        _animator = GetComponent<Animator>();
        hitbox = transform.Find("HitboxGameObjectName").GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("MeleeAttack");
            Invoke("ActivateHitbox", 0.2f);
            Invoke("DeactivateHitbox", 0.4f);
        }
    }

    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }

    IEnumerable AttackContinuously()
    {
        yield return new WaitForSeconds(punchPeriod);
    }
}
