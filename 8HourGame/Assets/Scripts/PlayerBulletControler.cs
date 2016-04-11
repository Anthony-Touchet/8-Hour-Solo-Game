using UnityEngine;
using System.Collections;

public class PlayerBulletControler : MonoBehaviour {

    public int damage;      //How much health will be lost on hitting an actor.
    Rigidbody bullRB;       //the Bullet's RigidBody
    private Vector3 fireAt;
    private GameObject player;
    public bool live;

    public int bullSpeed = 500; //Bullet's speed.


    void Start()
    {
        player = GameObject.Find("Player");
        bullRB = gameObject.GetComponent<Rigidbody>();  //Get RigidBody
        bullRB.useGravity = false;                      //Turn off the bullet's gravity.
        live = true;

        fireAt = gameObject.transform.position - player.gameObject.transform.position;  //Fire from the player away from the player
        
        bullRB.AddForce(fireAt * bullSpeed);               //Apply a force. 
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Terrain")   //if hit terrain
        {
            bullRB.useGravity = true;           //Bullet has gravity            
        }

        if (other.gameObject.tag == "Enemy")   //if hit terrain
        {
            bullRB.useGravity = true;           //Bullet has gravity            
        }

        if (other.gameObject.tag == "EnemyBullet")   //if hit Enemy Bullet
        {          
            bullRB.useGravity = true;           //Bullet has gravity
        }

        if (other.gameObject.tag == "PlayerBullet")   //if hit Enemy Bullet
        {
            bullRB.useGravity = true;           //Bullet has gravity
            live = false;                       //Bullet is dead
        }
    }
}
