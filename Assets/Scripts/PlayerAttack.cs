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

    void Start()
    {
        _animation = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diference.Normalize();
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(diference.y, diference.x));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animation.SetBool("Is_attacking", true);
        }

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90);
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
