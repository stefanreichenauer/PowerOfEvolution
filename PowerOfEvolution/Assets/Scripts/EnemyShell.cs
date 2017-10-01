using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell : MonoBehaviour {

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Player player;

    public int health = 10;
    public int experienceBase = 100;

    
    public void takeDamage(int healthLoss)
    {
        health = Mathf.Max(0, health - healthLoss);
        Debug.Log("Enemy healthLoss: health - " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.increaseExperiencePoints(experienceBase);
        Destroy(gameObject);

    }
}
