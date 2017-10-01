using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour {

    Player player;

    public int health = 100;
    public int experienceBase = 100;

    public Destruction destruct;

    BoatSpawner boatSpawner;
    public GameObject spawnpoint;

    public void Construct(Player Player, GameObject spawn, BoatSpawner BoatSpawner)
    {
        player = Player;
        spawnpoint = spawn;
        boatSpawner = BoatSpawner;
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
        Debug.Log("Enemy healthLoss: health - " + health);
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("boat_destroyed");
            Die();
        }
    }

    void Die()
    {
        player.increaseExperiencePoints(experienceBase);
        if (destruct != null)
        {
            destruct.destroyed = true;
        }
        else
        {
            Debug.Log("Enemy Destroy - ");
            Destroy(gameObject);

        }
        boatSpawner.removeActiveBoat(gameObject);
        Destroy(gameObject);

    }

}
