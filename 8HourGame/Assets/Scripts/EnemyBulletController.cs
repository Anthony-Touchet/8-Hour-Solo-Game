using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

    public int damage;      //How much health will be lost on hitting an actor.
    Rigidbody bullRB;       //the Bullet's RigidBody
    private Vector3 fireAt;
    public GameObject firer;

    public int bullSpeed = 500; //Bullet's speed.

    public enum BulletState //Bullet's state
    {
        LIVE,
        DEAD,
    }
    public BulletState currentState;    //Bullet's currrent state.

    void Start()
    {       
        bullRB = gameObject.GetComponent<Rigidbody>();  //Get RigidBody
        bullRB.useGravity = false;                      //Turn off the bullet's gravity.

        fireAt = gameObject.transform.position - firer.gameObject.transform.position;  //Fire from the player away from the player

        bullRB.AddForce(fireAt * bullSpeed);               //Apply a force. 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")   //if hit terrain
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Enemy")   //if hit Enmey
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "EnemyBullet")   //if hit Enmey
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "PlayerBullet")   //if hit player Bullet
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")   //if hit player
        {
            Destroy(this.gameObject);
        }
    }
}
