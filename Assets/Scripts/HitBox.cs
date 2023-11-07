using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.attachedRigidbody.AddForce(new Vector2 (25,25),ForceMode2D.Impulse);
            collision.GetComponent<Enemy>().TakeDamage(_player.Damage);
        }
    }


}
