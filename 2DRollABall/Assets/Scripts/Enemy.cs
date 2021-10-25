using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public Transform player;
    public float moveSpeed = 2f;
    public int damage = 25;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    
    // Start is called before the first frame update

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }
    

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        PlayerController player = collider.GetComponent<PlayerController>();
        if(player != null){
            player.TakeDamage(damage);
            Debug.Log("Player took " + damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health < 0){
            Die();
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    // Update is called once per frame
    void Die()
    {
        //Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
