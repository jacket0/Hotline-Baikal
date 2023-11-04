using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animation;
    public float AttackTime;
    public float StartTimeAttack;

    public float timeDestroy = 3f;
    public float speed = 3f;
    private Transform attackLocation;
    private float attackRange;
    private LayerMask enemies;

    public Rigidbody2D rb;
    Coroutine attackCoroutine;
    [SerializeField] float punchPeriod = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Invoke("DestroyBullet", timeDestroy);
        _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animation.SetBool("Is_attacking", true);
        }

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

    }

    IEnumerable AttackContinuously()
    {
        yield return new WaitForSeconds(punchPeriod);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
