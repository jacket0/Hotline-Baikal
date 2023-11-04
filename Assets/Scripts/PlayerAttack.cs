using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animation;

    public Rigidbody2D rb;
    Coroutine attackCoroutine;
    [SerializeField] float punchPeriod = 1;

    void Start()
    {
        _animation = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animation.SetBool("Is_attacking", true);
        }
    }

    IEnumerable AttackContinuously()
    {
        yield return new WaitForSeconds(punchPeriod);
    }
}
