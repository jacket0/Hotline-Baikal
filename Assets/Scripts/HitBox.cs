using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private ScoreDisplay _scoreDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        _scoreDisplay.KillTimer();
        _scoreDisplay.Kill();
    }

    void Start()
    {
        _scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
