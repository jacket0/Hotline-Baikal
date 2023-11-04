using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTrasform;
    public float moveSpeed = 2f;
    
    void Update()
    { 
        transform.position = Vector2.MoveTowards(transform.position, playerTrasform.position, moveSpeed * Time.deltaTime);
    }
}
