using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;

    public int health = 100;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int healthLoss)
    {
        health = Mathf.Max(0, health - healthLoss);
        Debug.Log("Enemy healthLoss: health - " + health);
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.increaseExperiencePoints(10);
        Destroy(gameObject);

    }
    
}
