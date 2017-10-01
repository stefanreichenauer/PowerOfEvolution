using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrab : MonoBehaviour {


    Player player;

    public int health = 100;
    public int experienceBase = 100;
    
    CrabSpawner crabSpawner;
    public GameObject spawnpoint;

    public void Construct(Player Player, GameObject spawn, CrabSpawner CrabSpawner)
    {
        player = Player;
        spawnpoint = spawn;
        crabSpawner = CrabSpawner;
    }

    // Use this for initialization
    void Start()
    {
        // destruct = GetComponent<Destruction>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int healthLoss)
    {
        health = Mathf.Max(0, health - healthLoss);
        Debug.Log("EnemyCrab healthLoss: health - " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.increaseExperiencePoints(experienceBase);

        crabSpawner.removeActiveCrab(gameObject);
        Destroy(gameObject);

    }
}
