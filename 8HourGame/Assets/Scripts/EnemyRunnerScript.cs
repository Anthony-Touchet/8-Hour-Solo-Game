using UnityEngine;
using System.Collections;
using System;

public class EnemyRunnerScript : Actor {

    PlayerController player;
    public Vector3 offest;
    Vector3 movement;

    void Lerp(Vector3 vec)    //Function for player movement
    {
        gameObject.transform.position = new Vector3(transform.position.x + vec.x, transform.position.y + vec.y, transform.position.z + vec.z);
    }

    // Use this for initialization
    void Start () {
        offest = new Vector3(0, 0, 0);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        health = 10;   //Player's Health: how much x before destroyed.
        speed = 2;      //Speed of the player. the higher it is the slower he will move
        bullDam = 10;   //How much damage the enemy will take.
        fireRate = 1f;  //How fast the player will be able to fire.
    }
	
	// Update is called once per frame
	override public void Update () {
        base.Update();  //Check to see if health is zero.

        if(gameObject.transform.position.x != player.gameObject.transform.position.x)
        {
            offest.x = gameObject.transform.position.x - player.gameObject.transform.position.x;
        }

        else
        {
            offest.x = 0;
        }

        if (gameObject.transform.position.z != player.gameObject.transform.position.z)
        {
            offest.z = gameObject.transform.position.z - player.gameObject.transform.position.z;
        }

        else
        {
            offest.z = 0;
        }

        movement.x = offest.x / Math.Abs(offest.x);
        movement.z = offest.z / Math.Abs(offest.z);

        Lerp(-(movement) * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyBullet")  //If it's an enemy bullet
        {
            health -= GetComponent<EnemyBullet>().damage;   //Take damage
        }

        if (other.gameObject.tag == "PlayerBullet") //if it is a player bullet
        {
            health -= player.bullDam;
        }
    }
}
