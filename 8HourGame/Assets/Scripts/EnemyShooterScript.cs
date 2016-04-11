using UnityEngine;
using System.Collections;

public class EnemyShooterScript : Actor {

    PlayerController player;
    Vector3 offset;
    float nextFire;

    public GameObject bullet;
    public GameObject bullSpawn;
    public int expWorth;

    void Fire()
    {
        if (Time.time >= nextFire) //if Space bar is pressed down, ammo is greater than 0, and time is greater than or equal to time when you can fire again.
        {
            nextFire = fireRate + Time.time;    //Sets the next fire
            GameObject temp;    //Bullet that you just spawned based off a position.
            temp = Instantiate(bullet, bullSpawn.transform.position, new Quaternion()) as GameObject;
            temp.GetComponent<EnemyBulletController>().firer = this.gameObject;
            temp.GetComponent<EnemyBulletController>().damage = bullDam;    //Bullet's damage is equal to player's
            
        }
    }

    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();    //Finds Player
        health = 20;   //Player's Health: how much x before destroyed.
        speed = 2;      //Speed of the player. the higher it is the slower he will move
        bullDam = 10;   //How much damage the enemy will take.
        fireRate = 5f;  //How fast the player will be able to fire.
        expWorth = 20;
    }
	
	// Update is called once per frame
	override public void Update () {
        if (health <= 0)
        {
            player.GetComponent<PlayerLevelControler>().currentExp += expWorth;
        }
        base.Update();

        gameObject.transform.LookAt(player.gameObject.transform.position);  //Follows the Player
        Fire();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyBullet")  //If it's an enemy bullet
        {
            health -= other.gameObject.GetComponent<EnemyBulletController>().damage;   //Take damage
        }

        if (other.gameObject.tag == "PlayerBullet" && other.gameObject.GetComponent<PlayerBulletControler>().live == true) //if it is a player bullet
        {
            health -= other.gameObject.GetComponent<PlayerBulletControler>().damage;
            other.gameObject.GetComponent<PlayerBulletControler>().live = false;
        }
    }
}
