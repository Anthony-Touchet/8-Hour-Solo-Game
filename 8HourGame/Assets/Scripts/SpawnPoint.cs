using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour {

    public float spawnRate;
    float nextSpawn;
    public GameObject spawning;
    public int spawnLimit;
    public List<GameObject> spawns; 

	void Start () {
        spawns = new List<GameObject>();
        SpawnIn();
	}
	
	// Update is called once per frame
	void Update () {
        foreach(GameObject e in spawns)
        {
            if(e == null)
            {
                spawns.Remove(e);
                nextSpawn = Time.time + spawnRate;
            }
        }

        if (Time.time >= nextSpawn && spawns.Count < spawnLimit)
        {
            SpawnIn();         
        }
	}

    void SpawnIn()
    {
        GameObject temp;
        temp = Instantiate(spawning, gameObject.transform.position, new Quaternion()) as GameObject;
        spawns.Add(temp);
    }
}
