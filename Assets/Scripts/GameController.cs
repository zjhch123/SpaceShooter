using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Vector3 spawnValues;
	public GameObject[] hazards;
	public int numPreWave = 10;

	public float startWait = 2f; // 出现小行星之前的等待时间
	public float spawnWait = 1f; // 小行星间隔时间

	public float waveWait = 4f; // 每波之间时间间隔

	public GameObject player;

	void Start () {
		Debug.Log ("Game Start...");
		StartCoroutine (SpawnWaves());
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
		
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(this.startWait);
		while (true) {
			for (int i = 0; i < numPreWave; i++) {
				Spawn ();
				yield return new WaitForSeconds(this.spawnWait);
			}
			yield return new WaitForSeconds (this.waveWait);
		}
	}

	void Spawn() {
		GameObject o = hazards [Random.Range (0, hazards.Length)];
		Vector3 p = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion q = Quaternion.identity;
		Instantiate (o, p, q);
	}

}
