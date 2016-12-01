using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class BleacherController : MonoBehaviour {
	public GameObject leftBleacher;
	public GameObject rightBleacher;
	public float speed;
	public static int pauseTime;

	// Use this for initialization
	void Start () {
		pauseTime = 0;
		StartCoroutine (WaitHalfSecond ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController._paused) {
			if (pauseTime > 0) {
				Debug.Log(pauseTime);
			} else {
				this.leftBleacher.transform.localPosition += new Vector3 (0, 0, -speed);
				this.rightBleacher.transform.localPosition += new Vector3 (0, 0, speed);
			}
		}

	}

	IEnumerator WaitHalfSecond() {
		while (true) { 
			yield return new WaitForSeconds (1f);
			if (pauseTime > 0) {
				pauseTime--;
			}
		}
	}
}
