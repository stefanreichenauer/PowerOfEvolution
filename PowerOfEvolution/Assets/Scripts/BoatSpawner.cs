using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour {
    public Player player;
    public GameObject boat;

    public List<GameObject> spawnpoints = new List<GameObject>();

    List<GameObject> activeBoats = new List<GameObject>();
    List<GameObject> spawnpointsInUse = new List<GameObject>();

    // Use this for initialization
    void Start () {
        spawnBoat();
	}
	
	// Update is called once per frame
	void Update () {
		if(activeBoats.Count < 2)
        {
            spawnBoat();
        }
	}

    GameObject getRandomSpawnpoint()
    {
        GameObject randomSpawnpoint = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Count - 1)];

        spawnpointsInUse.Add(randomSpawnpoint);
        spawnpoints.Remove(randomSpawnpoint);

        return randomSpawnpoint;
    }

    void spawnBoat()
    {
        GameObject randomSpawnpoint = getRandomSpawnpoint();
        GameObject spawnedBoat = Instantiate(boat, randomSpawnpoint.transform);
        spawnedBoat.GetComponent<EnemyBoat>().Construct(player, randomSpawnpoint, this);
        activeBoats.Add(spawnedBoat);
    }

    public void removeActiveBoat(GameObject destroyedBoat)
    {
        activeBoats.Remove(destroyedBoat);
        GameObject removeSpawnpoint = destroyedBoat.GetComponent<EnemyBoat>().spawnpoint;
        spawnpointsInUse.Remove(removeSpawnpoint);
        spawnpoints.Add(removeSpawnpoint);
    }
}
