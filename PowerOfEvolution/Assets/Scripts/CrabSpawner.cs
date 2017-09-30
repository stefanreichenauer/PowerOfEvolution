using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSpawner : MonoBehaviour {

    public Player player;
    public GameObject crab;

    public List<GameObject> spawnpoints = new List<GameObject>();

    List<GameObject> activeCrabs = new List<GameObject>();
    List<GameObject> spawnpointsInUse = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        spawnCrab();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCrabs.Count < 2)
        {
            spawnCrab();
        }
    }

    GameObject getRandomSpawnpoint()
    {
        GameObject randomSpawnpoint = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Count - 1)];

        spawnpointsInUse.Add(randomSpawnpoint);
        spawnpoints.Remove(randomSpawnpoint);

        return randomSpawnpoint;
    }

    void spawnCrab()
    {
        GameObject randomSpawnpoint = getRandomSpawnpoint();
        GameObject spawnedBoat = Instantiate(crab, randomSpawnpoint.transform);
        spawnedBoat.GetComponent<EnemyCrab>().Construct(player, randomSpawnpoint, this);
        activeCrabs.Add(spawnedBoat);
    }

    public void removeActiveCrab(GameObject destroyedCrab)
    {
        activeCrabs.Remove(destroyedCrab);
        GameObject removeSpawnpoint = destroyedCrab.GetComponent<EnemyCrab>().spawnpoint;
        spawnpointsInUse.Remove(removeSpawnpoint);
        spawnpoints.Add(removeSpawnpoint);
    }
}
