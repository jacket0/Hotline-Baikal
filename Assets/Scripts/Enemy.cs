using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int attackDistance = 1;
    public int attackDamage = 10;
    public LayerMask playerLayer;

    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, player.position) < attackDistance)
            {
                isAttacking = true;
                Attack();
            }
        }
    }

    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackDistance, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().GetDamage(attackDamage);
        }

        Invoke("ResetAttack", 1f);
    }

    void ResetAttack()
    {
        isAttacking = false;
    }
}
