using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin = -6.8f;
	public float xMax = 6.8f;

	public float zMin = -1.7f;
	public float zMax = 16f;
}

public class PalyerController : MonoBehaviour {
	
	public float speed = 10f;

	public Boundary bound;

	public GameObject bolt; // 发射子弹
	public Transform spawnPos; // 发射位置

	public float fireRate = 0.25f; // 发射时间间隔
	public float nextFire; // 下次发射时间

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bolt, spawnPos.position, spawnPos.rotation);
			GetComponent<AudioSource>().Play();

		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (h, 0f, v);

		Rigidbody rBody = GetComponent<Rigidbody> ();

		rBody.velocity = speed * move;



		rBody.position = new Vector3 (
			Mathf.Clamp(rBody.position.x, bound.xMin, bound.xMax), 
			0, 
			Mathf.Clamp(rBody.position.z, bound.zMin, bound.zMax)
		);

	}

}
