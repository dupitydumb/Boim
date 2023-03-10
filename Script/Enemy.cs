using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public int damage;
    public float speed;
    

    [HideInInspector]
    public Transform player;

    public float timeBetweenAttack;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage (int amount) {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



}
