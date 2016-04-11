using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float deathTime;
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, deathTime);
	}
}
