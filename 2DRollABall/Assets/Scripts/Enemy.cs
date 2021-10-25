using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public Transform player;
    // Start is called before the first frame update

    public void update(){
                print("Hello?");
        Vector3 direction = player.position - transform.position;
        Debug.Log(direction);

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health < 0){
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        //Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
