using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public static GameObject player;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		StartCoroutine ("PointToPlayer");
	}
	
	// Update is called once per frame

	void Update ()
	{
		if (!GameController._paused) {
			this.gameObject.transform.Translate (Vector3.forward * .125f);
			if (this.transform.position.y < 88) {
				this.transform.position = new Vector3 (this.transform.position.x, 89.6f, this.transform.position.z);
				this.transform.rotation = Quaternion.identity;
			}
		}
	}


	IEnumerator PointToPlayer ()
	{
		while (true) {
			yield return new WaitForSeconds (1f);
			this.transform.LookAt (player.transform);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Sword") {
			GameObject.Destroy (this.gameObject);
			BleacherController.pauseTime++;
		}
	}

}
