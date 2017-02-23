using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Boundary") {
			return;
		}
		Destroy (other.gameObject);
		Destroy (this.gameObject);
		Instantiate (explosion, this.transform.position, this.transform.rotation);
		if (other.gameObject.tag == "Player") {
			Instantiate (playerExplosion, this.transform.position, this.transform.rotation);
		}
	}


}
