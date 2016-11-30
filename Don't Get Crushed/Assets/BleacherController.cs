using UnityEngine;
using System.Collections;

public class BleacherController : MonoBehaviour {
	public GameObject leftBleacher;
	public GameObject rightBleacher;
	public float speed;
	public bool paused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!paused) {
			this.leftBleacher.transform.localPosition += new Vector3 (0, 0, -speed);
			this.rightBleacher.transform.localPosition += new Vector3 (0, 0, speed);
		}
	}
}
