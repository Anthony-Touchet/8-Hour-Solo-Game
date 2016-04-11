using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
    protected float speed;
    public int health;
    public int bullDam;
    protected float fireRate;

	public virtual void Update () {
	    if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
