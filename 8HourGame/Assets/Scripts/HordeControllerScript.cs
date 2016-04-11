using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HordeControllerScript : MonoBehaviour {
    public GameObject[] tempEnemies;
    public List<GameObject> enemies;

    Text remainEnem;
	// Use this for initialization
	void Start () {
        remainEnem = GameObject.Find("RE").GetComponent<Text>();
        tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in tempEnemies)
        {
            enemies.Add(e);
        }
        remainEnem.text = "Enemies Remaining: " + enemies.Count.ToString();
	}
	
	// Update is called once per frame
	void Update () {

        foreach(GameObject e in enemies)
        {
            if(e == null)
            {
                enemies.Remove(e);
                remainEnem.text = "Enemies Remaining: " + enemies.Count.ToString();
            }
        }
	    if(enemies.Count == 0)
        {
            Debug.Log("You Win!!!");
        }
	}
}
