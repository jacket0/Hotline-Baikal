using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int Hp { get; private set; }
    [SerializeField] public int Damage { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDamage(int damage)
    {
        Hp -= damage;
    }

    public void Attack()
    {

    }
}
