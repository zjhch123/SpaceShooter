using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

	public float lifeTime;
	public float reloadTime;
	public GameObject player;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, lifeTime);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
	

}
