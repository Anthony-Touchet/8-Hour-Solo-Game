using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
    protected float speed;
    public int health;
    public int bullDam;
    public float fireRate;

    public GameObject deathParticles;

	public virtual void Update () {
	    if(this.health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathParticles, gameObject.transform.position, new Quaternion());
        }
	}
}
