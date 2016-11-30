using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public GameObject cover;
	public int timeSpent;
	public Text text;
	public bool b1;
	public bool b2;

	// Use this for initialization
	void Start () {
		StartCoroutine ("CountForSeconds");
	}

	// Update is called once per frame
	void Update () {
		
		if (b1 && b2) {
			cover.SetActive(true);
			StartCoroutine(restartCurrentScene());
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "water") {
			
			cover.SetActive(true);
			float f = 0f;
			while (f <= 1) {	
				f += 0.01f;

			}
			StartCoroutine(restartCurrentScene());
		}
	}

	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "b1") {

			b1 = true;
		}
		if (collisionInfo.gameObject.tag == "b2") {
			b2 = true;
		}
	}

	void OnCollisionExit(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "b1") {
			b1 = false;
		}
		if (collisionInfo.gameObject.tag == "b2") {
			b2 = false;
		}
	}

	public IEnumerator CountForSeconds() {
		timeSpent = 0;
		for(;;) {
			yield return new WaitForSeconds (1f);
			timeSpent++;
			text.text = "Time Spent: " + timeSpent + " seconds";
		}

	}

	public IEnumerator restartCurrentScene()
	{
		float time = 0f;

		while (true) {
			if (time >= 2) {
				Debug.Log ("SCENE");
				int scene = SceneManager.GetActiveScene ().buildIndex;

				SceneManager.LoadScene (scene, LoadSceneMode.Single);
			}
			yield return new WaitForSeconds (.01f);

			cover.GetComponent<RawImage> ().color = new Color (0f, 0f, 0f, time);
			Debug.Log (time);
			time += .01f;
		}
	}
}
